using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTrans : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.Space)){ 
            StartCoroutine(LoadScene());
        }
       */
    }

    IEnumerator  LoadScene ()
    {
        transitionAnim.SetTrigger("cenaFim");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
