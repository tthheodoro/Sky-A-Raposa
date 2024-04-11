using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE,PickUp,Examine}
    public enum ItemType { Staic, Consumables }
    [Header("Attributes")]
    public InteractionType interactType;
    public ItemType type;
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom events")]
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    public  void Interact()
    {
        switch (interactType)
        {
            case InteractionType.PickUp:
                //add objeto para PickedUpItem Lista
                FindObjectOfType<InventorySystem>().PickUp(gameObject);
                //elemina o objeto
                gameObject.SetActive(false);
                break;

            case InteractionType.Examine:
                //chama o examine item no interaction system
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;
            default:
                Debug.Log("NULL TIME");
                break;
        }

        //chama o custom event
        customEvent.Invoke();
    }

}
