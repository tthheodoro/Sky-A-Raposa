using System.Collections;
using UnityEngine;

public class Fox : MonoBehaviour
{
    
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Collider2D standingCollider,crouchingCollider;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] Transform overheadCheckCollider;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    const float overheadCheckRadius = 0.2f;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpPower = 500;
    [SerializeField] int totalJumps;
    int availableJumps;
    float horizontalValue;
    float runSpeedModifier = 2f;
    float crouchSpeedModifier = 0.5f;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource hurtSound;


    [SerializeField] bool isGrounded;
    bool isRunning;
    bool facingRight = true;
    bool crouchPressed;
    bool multipleJump;
    bool coyoteJump;
    bool isDead=false;
    void Awake()    
    {
        availableJumps = totalJumps;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(CanMoveOrInteract()==false )
        return;
        //define a  yVelocity in the animator

        animator.SetFloat("yVelocity", rb.velocity.y);

        //guarda valor horizontal
        horizontalValue = Input.GetAxisRaw("Horizontal");


        //se LShift for Acionado abilita corrida
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;

        //se LShift for liberto desabilita corrida
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;

        //se pressionado  jump button ativa o salto
        if (Input.GetButtonDown("Jump"))
            Jump();
            


        //se pressionado  jump crunch ativa o crouch
        if (Input.GetButtonDown("Crouch"))
            crouchPressed = true;
        //senao desativa
        else if (Input.GetButtonUp("Crouch"))
            crouchPressed = false; 
    }

    void FixedUpdate()
    {
        Groundcheck();
        Move(horizontalValue, crouchPressed);
    }

    bool CanMoveOrInteract ()
    {
        bool can = true;

        if (FindObjectOfType<InteractionSystem>().isExamining)
            can = false;
        if (FindObjectOfType<InventorySystem>().isOpen)
            can = false;
        if (isDead)
            can = false;
        return can;
    }
    void Groundcheck()
    {
        bool wasGrounded = isGrounded;

        isGrounded = false;
        //verificar se o grouncheckObject esta a colidir com o outro 
        //2d colliders que estao na ground layer
        //se sim (isgrounded true) senao (isgrounded false)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            if (!wasGrounded)
            {
                availableJumps = totalJumps;
                multipleJump = false;  
            }
        }
        else
        {
            if (wasGrounded)
                StartCoroutine(CoyoteJumpDelay());
        }

        //assim que tivermos no chão o "Jump" bool desativa 
        animator.SetBool("Jump", !isGrounded); 
    }

    IEnumerator CoyoteJumpDelay()
    {
        coyoteJump = true;
        yield return new WaitForSeconds(0.2f);
        coyoteJump = false;
    }
    void Jump()
    {
        if (isGrounded)
        {
            multipleJump = true;
            availableJumps--;
            rb.velocity = Vector2.up * jumpPower;
            jumpSound.Play();
            animator.SetBool("Jump", true);
        }
        else
        {
            if(coyoteJump)
            {
                multipleJump = true;
                availableJumps--;
                rb.velocity = Vector2.up * jumpPower;
                jumpSound.Play();
                animator.SetBool("Jump", true);
            }

            if(multipleJump && availableJumps>0)
            {
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                jumpSound.Play();
                animator.SetBool("Jump", true); 
            }
        }
    }

   void Move(float dir,  bool CrouchFlag)
    {
        #region Crouch

        //Se tiver agachado e desativar agachar 
        //checar overhead para colisão com ground itens
        //se tiver não tiver continua agachado, senão  deixa de agachar
        if(!CrouchFlag)
        {
            if(Physics2D.OverlapCircle(overheadCheckCollider.position,overheadCheckRadius,groundLayer))
            {
                CrouchFlag = true;
            }
        }

        animator.SetBool("Crouch", CrouchFlag);
        standingCollider.enabled = !CrouchFlag;
        crouchingCollider.enabled = CrouchFlag;

        #endregion
        #region Move & Run
        //colocar o valor de x usando dir speed
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        //se estiver a correr multiplica a modificador de velocidade
        if (isRunning)
            xVal *= runSpeedModifier;
        //se estiver a correr multiplica a modificador de velocidade
        if (CrouchFlag)
            xVal *= crouchSpeedModifier;
        // Cria vec2 para a velocidade
        Vector2 targerVelocity = new Vector2(xVal,rb.velocity.y);
        //velocidade do player
        rb.velocity = targerVelocity;

        //se olhar para a direita e clicar esquerda (gira para esquerda)
        if(facingRight && dir<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        //se olhar para a esquerda e clicar direita (gira para direia)
        else if (!facingRight && dir>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        //Debug.Log(rb.velocity.x);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
    }


    public void Die()
    {
        isDead = true;
        //FindObjectOfType<LevelManager>().Restart();
        GameController.instance.ShowGameOver();
        Destroy(gameObject);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);

        }
    }
}
