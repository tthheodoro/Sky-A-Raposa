using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public int score;
    public Text scoreText;
    public Text Total;

    public static int total;
     
    public int totalscore;

    public GameObject gameOver;

    public static GameController instance;

    [SerializeField] private AudioSource dieSound;


    void Start()
    {
        instance = this;
        
        totalscore =PlayerPrefs.GetInt("score");
         Debug.Log(PlayerPrefs.GetInt("score"));

    }

    public void UpdateScoreText()
    {
        score++;
        scoreText.text = score.ToString();

        totalscore++;

        total = totalscore;

        Total.text = total.ToString();

        PlayerPrefs.SetInt("score", totalscore);


        
    }


    public void ShowGameOver()
    {
        dieSound.Play();
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }
}


   
