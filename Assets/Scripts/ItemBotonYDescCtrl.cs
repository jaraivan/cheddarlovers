using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBotonYDescCtrl : MonoBehaviour {

	// Use this for initialization
	private Image image;
	private Text textoDescripcion;
	private Text textoOro;

	public Item itemPrefab;


	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


		//pone las cosas en el mercado
	public void SetealeTodo(Item item) {
		itemPrefab = item;
		textoDescripcion = transform.Find("RawImage").gameObject.transform.Find("TextoDescripcion").gameObject.GetComponent<Text>();
		textoOro = transform.Find("Precio").gameObject.transform.Find("Panel").gameObject.transform.Find("TextoPrecio").gameObject.GetComponent<Text>();
		image = transform.Find("BotonItem").gameObject.transform.Find("ImagenDelItem").gameObject.GetComponent<Image>();
		textoDescripcion.text = item.descripcion;
		textoOro.text = item.precio.ToString();
		image.sprite = item.icono;
	}


	public void ComprarItem() {
		
		JugadorCtrl lucas = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>();
		if(lucas.GetOro() >= itemPrefab.precio) {
			lucas.RestarOro(itemPrefab.precio);
			lucas.AdquirirItem(itemPrefab);
			GameObject comprarPanel = GameObject.FindGameObjectWithTag("UI").gameObject.transform.Find("Mercado").gameObject.transform.Find("Canvas").gameObject.transform.Find("RawImage").gameObject.transform.Find("Comprar").gameObject;
			comprarPanel.SetActive(false);
		}
	}

	public void PanelDeCompra() {
		GameObject comprarPanel = GameObject.FindGameObjectWithTag("UI").gameObject.transform.Find("Mercado").gameObject.transform.Find("Canvas").gameObject.transform.Find("RawImage").gameObject.transform.Find("Comprar").gameObject;
		comprarPanel.SetActive(true);
	}

}
