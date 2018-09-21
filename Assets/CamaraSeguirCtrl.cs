using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguirCtrl : MonoBehaviour {

	public GameObject jugador;
	private Rigidbody2D rb2dJugador;
	// Use this for initialization
	void Start () {
		rb2dJugador = jugador.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Vector3 posicionJugador = rb2dJugador.position;
		transform.position = new Vector3(posicionJugador.x,posicionJugador.y,transform.position.z);
	}
}
