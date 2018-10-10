using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaMisionesCtrl : MonoBehaviour {

	// Use this for initialization
	private Mision[] misionesDelJugador;
	private bool estaActivo = false;
	void Start () {
		misionesDelJugador = GameObject.FindWithTag("Player").GetComponent<JugadorCtrl>().GetMisionesDelJugador();
		OcultarListaDeMisiones();

		OcultarTodasLasMisiones();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SiApretoElBoton(){
		if(!estaActivo){
			MostrarListaDeMisiones();
		}else{
			OcultarListaDeMisiones();
		}
	}

	public void MostrarListaDeMisiones(){
		estaActivo = true;
		gameObject.SetActive(true);
	}
	public void OcultarListaDeMisiones(){
		estaActivo = false;
		gameObject.SetActive(false);
	}

	void OcultarTodasLasMisiones(){
		GameObject.FindWithTag("Mision0UI").SetActive(false);
		GameObject.FindWithTag("Mision1UI").SetActive(false);
		GameObject.FindWithTag("Mision2UI").SetActive(false);
		GameObject.FindWithTag("Mision3UI").SetActive(false);
		GameObject.FindWithTag("Mision4UI").SetActive(false);
	}
}
