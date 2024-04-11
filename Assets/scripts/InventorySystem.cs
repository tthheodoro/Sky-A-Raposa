using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [Header("General Fields")]
    // Lista de itens apanhados
    public List<GameObject> items=new List<GameObject>();
    //flag  indica se o inventory se ta aberto ou nao
    public bool isOpen ;
    [Header("UI Items Section")]
    // Sistema de janela inventario
    public GameObject ui_Window;
    public Image[] items_images;
    [Header("UI Items Description")]
    public GameObject ui_description_Window;
    public Image description_Image;
    public Text description_Title;
    public Text description_Text;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        ui_Window.SetActive(isOpen);

        Update_UI();
    }

    //adiciona o item à lista de itens
    public void PickUp(GameObject item)
    {
        items.Add(item);

        Update_UI();
    }
    // atualiza o Ui elementos da janela do inventario
   void Update_UI()
    {
        HideAll();
        //para cada item na lista de itens
        //mostra a imagem respectiva 
        for(int i= 0;i<items.Count;i++)
        {
            items_images[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            items_images[i].gameObject.SetActive(true);
        }

    }
//esconde todas imagens dos itens 
    void HideAll()
    {
        foreach (var i in items_images)
        {
            i.gameObject.SetActive(false);
        }
        HideDescription();
    }
    public void ShowDescription(int id)
    {
        //seta a imagem
        description_Image.sprite = items_images[id].sprite;
        //seta o texto
        description_Title.text = items[id].name;
        //mostra a descrição
        description_Text.text = items[id].GetComponent<Item>().descriptionText;
            //mostra os elementos
        description_Image.gameObject.SetActive(true);
        description_Title.gameObject.SetActive(true);
        description_Text.gameObject.SetActive(true);
    }

    public void HideDescription()
    {
        description_Image.gameObject.SetActive(false);
        description_Title.gameObject.SetActive(false);
        description_Text.gameObject.SetActive(false);
    }

   public  void Consume(int  id)
    {
        if(items[id].GetComponent<Item>().type== Item.ItemType.Consumables)
        {
            Debug.Log($"CONSUMED {items[id].name}");
            //invoca o consumo do item
            items[id].GetComponent<Item>().consumeEvent.Invoke();
            //destroy num pequeno espaço tempo
            Destroy(items[id], 0.1f);
            //limpa o item da lista 
            items.RemoveAt(id);
            //Update UI
            Update_UI();
     
        }
    }
    
}
