using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoniaPaulinaCtlr : MonoBehaviour {

	public GameObject lucas;
	public GameObject conversacion;
	private BoxCollider2D bc2d;

	private Queue<string> conversacionActual;
	private Mision misionActual;
	
	// Use this for initialization
	private int indiceDialogo = 0;
	void Start () {
		bc2d = GetComponent<BoxCollider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		this.ComportamientoJugando(col);
		this.ComportamientoConversando(col);
	}

	void OnTriggerEnter2D(Collider2D col){
		this.ComportamientoJugando(col);
		this.ComportamientoConversando(col);
	}
	void ActivarConversacion(){
		conversacion.SetActive(true);
		this.misionActual = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().GetAdministradorDeMisiones().GetMision();
		this.conversacionActual = CopiarConversacion(this.misionActual.GetDialogo().GetLineasDeTexto());
	}

	void DesactivarConversacion(Mision mision){
		JugadorCtrl lucas = FindObjectOfType<JugadorCtrl>();
		
		lucas.IniciarJugando();
		lucas.GetAdministradorDeMisiones().ActivarMision(mision);
		conversacion.SetActive(false);
	}

	Queue<string> CopiarConversacion(Queue<string> queueQueMePasan){
		Queue<string> nuevaQueue = new Queue<string>();
		
		foreach(string e in queueQueMePasan){
			nuevaQueue.Enqueue(e);
		}
		
		return nuevaQueue;
	}

	void ComportamientoJugando(Collider2D col){
		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Jugando){
			if(Input.GetKeyDown(KeyCode.Space)){
				col.gameObject.GetComponent<JugadorCtrl>().IniciarConversacion();
				ActivarConversacion();
				conversacion.GetComponentInChildren<Text>().text = this.conversacionActual.Dequeue();
			}
		}
	}

	void ComportamientoConversando(Collider2D col){
		if(col.gameObject.tag == "Player" && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Conversando){
			if(Input.GetKeyDown(KeyCode.Space)){
				
				if(this.conversacionActual.Count ==0){
					this.DesactivarConversacion(this.misionActual);
					}else{

					conversacion.GetComponentInChildren<Text>().text = this.conversacionActual.Dequeue();
					}
			}
		}
	}

}
