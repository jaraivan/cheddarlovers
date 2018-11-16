using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBotonYDescCtrl : MonoBehaviour {

	// Use this for initialization
	private Image image;
	private Text textoDescripcion;
	private Text textoOro;

	public Sprite pocionSprite;
	public Sprite polloSprite;
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetImagenPara(string nombreDeItem){
		image = transform.Find("BotonItem").gameObject.transform.Find("ImagenDelItem").gameObject.GetComponent<Image>();
		switch (nombreDeItem){
			case "pocion":
			image.sprite = pocionSprite;
			break;

			case "pollo":
			image.sprite = polloSprite;
			break;

		}

	}

	public void SetDescripcionPara(string nombreDeItem){
		textoDescripcion = transform.Find("RawImage").gameObject.transform.Find("TextoDescripcion").gameObject.GetComponent<Text>();
		switch (nombreDeItem){
			case "pocion":
			textoDescripcion.text = "Pocion: Sirve para restaurar puntos de salud";
			break;

			case "pollo":
			textoDescripcion.text = "Pollo: Sirve unicamente para la mision de Donia Paulina, no te lo podes comer, cagate de hambre boludo!";
			break;

		}
	}

	public void SetPrecioPara(string nombreDeItem){
		textoOro = transform.Find("Precio").gameObject.transform.Find("Panel").gameObject.transform.Find("TextoPrecio").gameObject.GetComponent<Text>();
		switch (nombreDeItem){
			case "pocion":
			textoOro.text = "50";
			break;

			case "pollo":
			textoOro.text = "5";
			break;

		}
	}


}
