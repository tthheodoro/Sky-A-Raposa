using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score2 : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D box;

    public GameObject collected;
    public int score;


    public static int totalscore;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

    }




    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            box.enabled = false;
          


            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.25f);
        }

    }

}



