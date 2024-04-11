
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class TrapObject : MonoBehaviour

{


    [SerializeField] private AudioSource hurtSound;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            hurtSound.Play();
            FindObjectOfType<LifeCount>().LoseLife();
        }
    }
}
