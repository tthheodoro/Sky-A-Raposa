using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetect : MonoBehaviour
{
    GameObject Enemy;

    Animator anim;

    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
       /* if(transform.position.y < -14)
        {
            Destroy(this.gameObject);
        }*/
    }

   
  private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Collider2D>().enabled = false;
        //Enemy.GetComponent<SpriteRenderer>().flipY = true;
        Enemy.GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("die");
        Destroy(gameObject, 1f);    
    }
}

