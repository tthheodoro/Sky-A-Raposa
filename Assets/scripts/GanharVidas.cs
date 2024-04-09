using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class GanharVidas : MonoBehaviour
{
    public GameObject collected;
    [SerializeField] private AudioSource itensSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            itensSound.Play();
            FindObjectOfType<LifeCount>().AddLife();
            collected.SetActive(true);
            Destroy(gameObject, 0.25f);
        }
    }
}
