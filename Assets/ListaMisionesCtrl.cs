using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListaMisionesCtrl : MonoBehaviour {

	// Use this for initialization
	private Queue<Mision> misionesEnLaUi;
	private bool estaActivo = false;
	public GameObject misionEnListaUI;
	void Start () {
		//misionesDelJugador = GameObject.FindWithTag("Player").GetComponent<JugadorCtrl>().GetMisionesDelJugador();
		OcultarListaDeMisiones();

		OcultarTodasLasMisiones();
		misionesEnLaUi = new Queue<Mision>(5);
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
		//GameObject.FindWithTag("Mision0UI").SetActive(false);
		//GameObject.FindWithTag("Mision1UI").SetActive(false);
		//GameObject.FindWithTag("Mision2UI").SetActive(false);
		//GameObject.FindWithTag("Mision3UI").SetActive(false);
		//GameObject.FindWithTag("Mision4UI").SetActive(false);
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
