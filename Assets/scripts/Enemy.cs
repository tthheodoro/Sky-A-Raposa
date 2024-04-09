
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    // referencia para pontos 
    public List<Transform> points;
    //valor int para proximo ponto
    public int nextID=0;
    //valor que é aplicado no id para mudar
    int idChangeValue = 1;
    //velocidade do movimento or voou
    public float speed = 2;

   

    private void Reset()
    {
        Init();
    }


    void Init()
    {
        //Make box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //create root object
        GameObject root = new GameObject(name + "_Root");
        //reseta posição da root para este gameobject
        root.transform.position = transform.position;
        //seta inimigo objeto como child root
        transform.SetParent(root.transform);
        //cria waypoints objeto
        GameObject waypoints = new GameObject("Waypoints");
        //reseta a posição dos waypoints to root
        //faz waypoint object child do root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //cria dois pontos (gameobject) e reseta a sua posição para waypoint object
        //faz os pontos children dos waypoint object
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        //init points list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
       
    }

   

    void MoveToNextPoint()
    {
        //Recebe o proximo ponto transform
        Transform goalPoint = points[nextID];
        //gira o inimigo transform para olhar para a direção do ponto
        if (goalPoint.transform.position.x > transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        //Move a frente do inimigo para o ponto pretendido
        transform.position = Vector3.MoveTowards(transform.position,goalPoint.position, speed*Time.deltaTime);
        //checar a distancia entre o inimigo para o ponto pretendido para ativiar próximo ponto 
        if(Vector2.Distance(transform.position,goalPoint.position)<1f)
        {
            //verifica se está no final da linha( faz a mudança para -1)
            //2 pontos(0,1) next == points.count(2)-1
            if(nextID==points.Count-1)
                idChangeValue = -1; 
            //verifica se está no final da linha( faz a mudança para +1)
            if(nextID == 0)
                idChangeValue = 1;
            //aplica a mudança no proximo nextID
            nextID += idChangeValue;
    

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log($"{name} Trap Triggers");
        }
    }
}
