using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour

{
   [Header("Detection Parameters")]
    //DeteçãoPonto
    public Transform detectionPoint;
    //deteção radio
    private const float detectionRadius=0.2f;
    //deteção Layer 
    public LayerMask detectionLayer;
    //cached trigger object
    public GameObject detectedObject;
    [Header("Examine Field")]
    //Janela de examine object
    public GameObject examineWindow;
    public Image examineImage;
    public Text examineText;
    public bool isExamining;

    void Update()
    {
     if(DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }

    bool InteractInput()
    {
       return Input.GetKeyDown(KeyCode.E);
    }

     bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);

        if(obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }

        
 
    }


    public void ExamineItem(Item item)
    {
        if(isExamining)
        {
   
            //esconde Janela de examine
            examineWindow.SetActive(false); ;
            //desativar bool
            isExamining = false;
        }
        else
        {
     
            //mostra imagem dos itens no meio
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            //escreve descrição  debaixo da imagem
            examineText.text = item.descriptionText;
            //Janela de examine
            examineWindow.SetActive(true);
            //ativar bool
            isExamining = true;
        }
    }
   
}
