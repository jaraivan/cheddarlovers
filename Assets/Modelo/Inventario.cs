
using System;
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
    public List<Item> items = new List<Item>(6);

    public List<Item> itemsEnElBaul= new List<Item>();
    
    
    public void AgregarItem(Item item)
    {
        //print(items.Count);
        //print(items.Count <= items.Capacity);
        if(items.Count >= items.Capacity){
        Debug.Log("No tenes espacio en el inventario");
        throw new InventarioLlenoException();
        } 
        
        this.items.Add(item);
        GameObject itemsParent = transform.Find("ItemsParent").gameObject;
        itemsParent.SetActive(true);
        ActualizarSlot(item);
    }

    public void QuitarItemDelBaul(Item item)
    {
        this.itemsEnElBaul.Remove(item);
    
    }
    public void AgregarItemDelBaul(Item item)
    {
        this.QuitarItem(item);
        this.itemsEnElBaul.Add(item);
        ActualizarSlot(null);
    }

    public void InteraccionBoton(){
        GameObject itemsParent = transform.Find("ItemsParent").gameObject;
        itemsParent.SetActive(!itemsParent.activeSelf);
    }

    public void ActualizarSlot(Item item) {
        List<SlotCtrl> hijos = new List<SlotCtrl>();
	
	    transform.Find("ItemsParent").gameObject.GetComponentsInChildren(true,hijos);

        SlotCtrl slotVacio = BuscarSlotVacio(hijos);
        slotVacio.AdquirirItem(item);
    }

    public void ActualizarSlotSacandoElItem(Item item) {
        List<SlotCtrl> hijos = new List<SlotCtrl>();
	
	    transform.Find("ItemsParent").gameObject.GetComponentsInChildren(true,hijos);

        SlotCtrl slotConItem = BuscarSlotConItem(hijos,item);
        slotConItem.itemPrefab = null;
        slotConItem.ActualizarImagen(null);
    }

    private SlotCtrl BuscarSlotVacio(List<SlotCtrl> hijos)
    {
        foreach(SlotCtrl s in hijos){
           if(s.EstaVacio()){
               return s;
           }
        }
        throw new InventarioLlenoException();

    }

    private SlotCtrl BuscarSlotConItem(List<SlotCtrl> hijos,Item item)
    {
        foreach(SlotCtrl s in hijos){
           if(s.itemPrefab == item){
               return s;
           }
        }
        throw new NoTienesEseItemEnNingunSlotException();

    }

    public bool TieneElItem(Item item){
      
        return this.items.Contains(item);
    }

    public void QuitarItem(Item item) {
        this.items.Remove(item);
        
    }

    public void QuitarElItemPorMision(Item item){
        this.items.Remove(item);
        ActualizarSlotSacandoElItem(item);
    }

    public List<Item> GetItemsEnBaul(){
        return this.itemsEnElBaul;
    }

    public void UsarItemEnLaPosicion(int unaPosicion){
        List<SlotCtrl> hijos = new List<SlotCtrl>();
	
	    transform.Find("ItemsParent").gameObject.GetComponentsInChildren(true,hijos);

        SlotCtrl slot = hijos[unaPosicion -1];
        if(slot.itemPrefab != null && slot.itemPrefab.consumible){
            GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().UsarItem(slot.itemPrefab);
            QuitarItem(slot.itemPrefab);
            slot.itemPrefab = null;
            slot.ActualizarImagen(null);
        }
    }

}