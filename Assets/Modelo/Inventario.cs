
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    #region Singleton
    public static Inventario instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Mas de una instancia del Inventario!!!");
            return;
        }
        instance = this;
    }
    #endregion
    public int espacio = 6;
    public List<Item> items = new List<Item>();
    
    
    public void AgregarItem(Item item)
    {
       /*  if(items.Count >= espacio){
            Debug.Log("No tenes espacio en el inventario");
            return;
        } */
        this.items.Add(item);
        GameObject itemsParent = transform.Find("ItemsParent").gameObject;
        itemsParent.SetActive(true);
        ActualizarSlot(item);
    }

    public void InteraccionBoton(){
        GameObject itemsParent = transform.Find("ItemsParent").gameObject;
        itemsParent.SetActive(!itemsParent.activeSelf);
    }

    public void ActualizarSlot(Item item) {
        List<SlotCtrl> hijos = new List<SlotCtrl>();
	
	 transform.Find("ItemsParent").gameObject.GetComponentsInChildren(true,hijos);
     
        hijos[0].AdquirirItem(item);
    }

}