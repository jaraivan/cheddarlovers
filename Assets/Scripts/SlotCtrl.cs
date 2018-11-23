using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCtrl : MonoBehaviour {

	public Item itemPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
}
