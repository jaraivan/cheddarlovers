using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoniaPaulinaCtlr : MonoBehaviour {

	public GameObject lucas;
	public GameObject conversacion;
	private BoxCollider2D bc2d;
	private Mision[] misiones = new Mision[5];
	// Use this for initialization
	private int indiceDialogo = 0;
	void Start () {
		bc2d = GetComponent<BoxCollider2D>();
		this.CrearPrimeraMisionDP();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Jugando){
			if(Input.GetKeyDown(KeyCode.Space)){
				col.gameObject.GetComponent<JugadorCtrl>().IniciarConversacion();
				ActivarConversacion();
				Mision primeraMision = (Mision) misiones.GetValue(0) ;
				conversacion.GetComponentInChildren<Text>().text = primeraMision.GetDialogo().GetLineasDeTexto()[indiceDialogo];
			}
		}
		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Conversando){
			if(Input.GetKeyDown(KeyCode.Space)){
				Mision primeraMision = (Mision) misiones.GetValue(0) ;
				if(indiceDialogo> primeraMision.GetDialogo().CantidadDeLineasDeTexto()-1){this.DesactivarConversacion();}
				conversacion.GetComponentInChildren<Text>().text = primeraMision.GetDialogo().GetLineasDeTexto()[indiceDialogo++];
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Jugando){
			if(Input.GetKeyDown(KeyCode.Space)){
				col.gameObject.GetComponent<JugadorCtrl>().IniciarConversacion();
				ActivarConversacion();
				Mision primeraMision = (Mision) misiones.GetValue(0) ;
				conversacion.GetComponentInChildren<Text>().text = primeraMision.GetDialogo().GetLineasDeTexto()[indiceDialogo];
			}
		}
		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Conversando){
			if(Input.GetKeyDown(KeyCode.Space)){
				Mision primeraMision = (Mision) misiones.GetValue(0) ;
				if(indiceDialogo> primeraMision.GetDialogo().CantidadDeLineasDeTexto()-1){this.DesactivarConversacion();}
				conversacion.GetComponentInChildren<Text>().text = primeraMision.GetDialogo().GetLineasDeTexto()[indiceDialogo++];
			}
		}
	}
	void ActivarConversacion(){
		conversacion.SetActive(true);
	}

	void DesactivarConversacion(){
		JugadorCtrl lucas = FindObjectOfType<JugadorCtrl>();
		lucas.IniciarJugando();
		indiceDialogo = 0;
		conversacion.SetActive(false);
	}

	void CrearPrimeraMisionDP(){

		Dialogo dialogoPrimeraMision = new Dialogo("Doña Paulina");

		dialogoPrimeraMision.AgregarLineaDeTextoLucas("Hola Doña Paulina");
		dialogoPrimeraMision.AgregarLineaDeTextoNPC("Hola Lucas, te veo preocupado pequeño, ¿Qué ha pasado?");
		dialogoPrimeraMision.AgregarLineaDeTextoLucas("Me acabo de enterar que mi padre tenía deudas, y me van sacar la casa si no les doy el dinero que quieren… Desde el accidente en la mina, no he conseguido trabajo, no se que voy a hacer!");
		dialogoPrimeraMision.AgregarLineaDeTextoNPC("Oh no que terrible! Me encantaría poder ayudarte, pero ahora mismo, no se me ocurre como…");
		dialogoPrimeraMision.AgregarLineaDeTextoNPC("Un momento, si haces algunos mandados para mi, podría darte unas monedas, no es mucho, pero por algo se empieza no?");
		dialogoPrimeraMision.AgregarLineaDeTextoLucas("Gracias! Dime que tengo que hacer");
		dialogoPrimeraMision.AgregarLineaDeTextoNPC("Ando necesitando algunas cosas del mercado, puedes ir a comprarlos y traerlos? Aquí tienes la lista de lo que necesito y el oro para eso…");
		Mision primeraMision = new Mision("Haciendo mandados a DoñaPaulina",dialogoPrimeraMision);
		misiones.SetValue(primeraMision,0);
	}

}
