using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaulSlotCtrl : MonoBehaviour {
	public Item itemPrefab;
	public void AdquirirItem(Item item){
		itemPrefab = item;
		ActualizarImagen(item);
	}

	public void ActualizarImagen(Item item){
		if(item == null) {
			transform.Find("Icono").gameObject.GetComponent<Image>().enabled = false;
		} else {
			transform.Find("Icono").gameObject.GetComponent<Image>().enabled = true;
			transform.Find("Icono").gameObject.GetComponent<Image>().sprite = item.icono;
		}
	}

    public bool EstaVacio()
    {
        return itemPrefab == null;
    }

	public void BotonSlot()
    {
		if(!EstaVacio()){
		GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AdquirirItem(itemPrefab);
		Inventario.instance.QuitarItemDelBaul(itemPrefab);
		itemPrefab=null;
		ActualizarImagen(null);
		}
    }
}
