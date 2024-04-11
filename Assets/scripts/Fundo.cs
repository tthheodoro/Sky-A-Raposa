using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fundo : MonoBehaviour
{
    private float length, stratpos;
    public GameObject cam;
    public float fundoeffect;


    void Start()    
    {
        stratpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1.1f - fundoeffect));
        float dist = (cam.transform.position.x * fundoeffect);
        transform.position = new Vector3(stratpos + dist, transform.position.y, transform.position.z);


        if (temp > stratpos + length) stratpos += length;
        else if (temp < stratpos - length) stratpos -= length;

    }
}
