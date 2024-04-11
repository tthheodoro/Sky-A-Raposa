using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
 public void PlayGame()
    {
        SceneManager.LoadScene("Jogo");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Info()
    {
        SceneManager.LoadScene("Info");
    }

    public void PrincipalMenu()
    {
        SceneManager.LoadScene("Menu");
    }



    public void Continue()
    {
        if(PlayerPrefs.GetInt("LoadSaved")==1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        }
        else
        { return; }
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }
}
