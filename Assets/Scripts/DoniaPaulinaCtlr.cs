using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoniaPaulinaCtlr : MonoBehaviour {

	public GameObject lucas;
	public GameObject conversacion;
	private BoxCollider2D bc2d;
	
	// Use this for initialization
	private int indiceDialogo = 0;
	void Start () {
		bc2d = GetComponent<BoxCollider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		Mision mision = col.gameObject.GetComponent<JugadorCtrl>().GetAdministradorDeMisiones().GetMision();
		Queue<string> queueDeTextoARecorrer = new Queue<string>(mision.GetDialogo().GetLineasDeTexto());
		


		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Jugando){
			if(Input.GetKeyDown(KeyCode.Space)){
				col.gameObject.GetComponent<JugadorCtrl>().IniciarConversacion();
				ActivarConversacion();
				conversacion.GetComponentInChildren<Text>().text = queueDeTextoARecorrer.Dequeue();
			}
		}
		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Conversando){
			if(Input.GetKeyDown(KeyCode.Space)){
				
				if(queueDeTextoARecorrer.Count ==0){
					this.DesactivarConversacion(mision);
					}else{

					conversacion.GetComponentInChildren<Text>().text = queueDeTextoARecorrer.Dequeue();
					}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		Mision mision = col.gameObject.GetComponent<JugadorCtrl>().GetAdministradorDeMisiones().GetMision();
		Queue<string> queueDeTextoARecorrer = new Queue<string>(mision.GetDialogo().GetLineasDeTexto());
		


		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Jugando){
			if(Input.GetKeyDown(KeyCode.Space)){
				col.gameObject.GetComponent<JugadorCtrl>().IniciarConversacion();
				ActivarConversacion();
				conversacion.GetComponentInChildren<Text>().text = queueDeTextoARecorrer.Dequeue();
			}
		}
		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Conversando){
			if(Input.GetKeyDown(KeyCode.Space)){
				
				if(queueDeTextoARecorrer.Count ==0){
					this.DesactivarConversacion(mision);
					}else{

					conversacion.GetComponentInChildren<Text>().text = queueDeTextoARecorrer.Dequeue();
					}
			}
		}
	}
	void ActivarConversacion(){
		conversacion.SetActive(true);
	}

	void DesactivarConversacion(Mision mision){
		JugadorCtrl lucas = FindObjectOfType<JugadorCtrl>();
		
		lucas.IniciarJugando();
		lucas.GetAdministradorDeMisiones().ActivarMision(mision);
		conversacion.SetActive(false);
	}


}
