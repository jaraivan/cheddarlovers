using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListaMisionesCtrl : MonoBehaviour {

	// Use this for initialization
	private Queue<Mision> misionesEnLaUi;
	public GameObject misionEnListaUI;
	void Start () {
		//misionesDelJugador = GameObject.FindWithTag("Player").GetComponent<JugadorCtrl>().GetMisionesDelJugador();

		misionesEnLaUi = new Queue<Mision>(5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SiApretoElBoton(){
		gameObject.SetActive(!gameObject.activeSelf);
	}


	public void ActivarAnimacionNuevaMision(){

	}

	public void AgregarNuevaMision(Mision mision){
		gameObject.SetActive(true);
		gameObject.SetActive(true);
		this.misionesEnLaUi.Enqueue(mision);
		GameObject verticalLayoutMisiones = GameObject.FindGameObjectWithTag("VerticalLayoutMisiones");
		GameObject misionEnUI = Object.Instantiate(misionEnListaUI,verticalLayoutMisiones.transform.position,Quaternion.identity);

		misionEnUI.transform.SetParent(verticalLayoutMisiones.transform,false);
		misionEnUI.GetComponentInChildren<Text>().text = mision.GetNombreMision();

	}
}
