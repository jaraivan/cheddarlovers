
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public List<Item> items = new List<Item>();
    public int espacio = 6;
    
    public void AgregarItem(Item item)
    {
        if(items.Count >= espacio){
            Debug.Log("No tenes espacio en el inventario");
            return;
        }
        this.items.Add(item);
    }

    public void InteraccionBoton(){
        GameObject itemsParent = transform.Find("ItemsParent").gameObject;
        itemsParent.SetActive(!itemsParent.activeSelf);
    }


}