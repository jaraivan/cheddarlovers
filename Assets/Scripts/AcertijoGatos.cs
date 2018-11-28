using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcertijoGatos : MonoBehaviour {

	// Use this for initialization
	private Text textoPantalla;
	private string codigo;
	public Item llave;
	void Start () {
		textoPantalla = transform.Find("PanelIngreso").gameObject.transform.Find("PanelPantalla").gameObject.transform.Find("TextoPantalla").GetComponent<Text>();
		codigo = "2448";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Boton0(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "0";
	}
	public void Boton1(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "1";
	}
	public void Boton2(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "2";
	}
	public void Boton3(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "3";
	}
	public void Boton4(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "4";
	}
	public void Boton5(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "5";
	}
	public void Boton6(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "6";
	}
	public void Boton7(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "7";
	}
	public void Boton8(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "8";
	}
	public void Boton9(){
		string actual = textoPantalla.text;
		textoPantalla.text = actual + "9";
	}
	public void BotonBorrar(){
		textoPantalla.text = "";
	}
	public void BotonOK(){
		ComprobarCodigo();
	}

	public void ComprobarCodigo(){
		if(textoPantalla.text == codigo){
			ComportamientoAcertijoFinalizado();
			return;
		}else{
			print("BARDEASTE!");
		}
	}

    private void ComportamientoAcertijoFinalizado()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AdquirirItem(llave);
		BotonSALIR();
		return;
    }

    public void BotonSALIR(){
		gameObject.SetActive(false);
	}

}
