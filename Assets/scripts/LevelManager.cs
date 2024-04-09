  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    Vector2 playerInitPosition;

    private void Start()
    {
        playerInitPosition = FindObjectOfType<Fox>().transform.position;
    }
    public void Restart()
    {
        //1-Reinicia a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //2- Reseta a posição do jogados,reset the score counter, reapper coins in game
        //guarda a posição inicial do jogador quando jogo iniciar
        //quando voltar a nascer reposiciona na posição inicial
     
    }
}
