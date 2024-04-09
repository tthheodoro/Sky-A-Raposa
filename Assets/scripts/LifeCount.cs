using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaning;
    private int maxLife;
    

    private void Start()
    {
        maxLife = livesRemaning;
    }

    //3 vidas - 3 imagens (0,1,2,[3])
    //2 vidas - 2 imagens (0,1,[2],[3])
    //1 vidas - 1 imagens (0,[1],[2],[3])
    //0 vidas - 0 imagens ([0,1,2,3]) lose 

    public void LoseLife()
    {
        //Se não restarem vidas não faz nada
        if(livesRemaning ==0)
         return; 
        //diminiu o valor de liveRemaning
        livesRemaning--;
        //esconde uma das images
        //lives[livesRemaning].enabled = false;

        lives[livesRemaning].gameObject.SetActive(false);
        //se não ouver mais vidas morremos
        if (livesRemaning==0)
        {
            FindObjectOfType<Fox>().Die();
           
        }
    }

   public void AddLife()
    {
        if(livesRemaning<maxLife)
        {
            lives[livesRemaning].gameObject.SetActive(true);
            livesRemaning += 1;
        }
      
    }



    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Return))
        //      LoseLife();
    }
}
