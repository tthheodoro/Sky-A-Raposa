using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
   
    public int iLevelToLoad;
    public string sLevelToLoad;

    [SerializeField] private AudioSource LVLSound;

    public bool useIntegerToLoadLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {


            LVLSound.Play();
            Invoke("LoadScene", 1f);
        }
    }
    void LoadScene()
    {
        if(useIntegerToLoadLevel)
        {
            
       
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
          
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
