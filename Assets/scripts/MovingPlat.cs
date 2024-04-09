using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    int goalPoint = 0;
    public float moveSpeed = 2;
    private void Update()
    {
        MoveToNextPoint();
    } 

    void MoveToNextPoint()
    {
        //mudar de posição da plataforma
        platform.position = Vector2.MoveTowards(platform.position,points[goalPoint].position,Time.deltaTime*moveSpeed);
    //verifica se estamos perto do proximo ponto
      if(Vector2.Distance(platform.position, points[goalPoint].position)<0.1f)
        {
            //muda para o proximo ponto requerido
            //verifica se chega no ultimo ponto e reseta o primeiro
            if (goalPoint == points.Count - 1)
                goalPoint = 0;
            else
                goalPoint++;
        }

    //se chegar no ponto muda para o proximo ponto
    }
}
