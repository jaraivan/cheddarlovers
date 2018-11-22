using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PerroCtrl : MonoBehaviour {
	
	private GameObject jugador;
	public float tiempoDeSuavizado = 0.5f;
	public float maxSpeed;
	public float distanciaConElJugador;
	Vector3 posInicial;
	Vector3 velocidad;
	private Vector3 target;

	// Use this for initialization

	void Start () {
		jugador = GameObject.FindWithTag("Player");
		
		posInicial = new Vector3(jugador.transform.position.x -1f,jugador.transform.position.y,transform.position.z);
		transform.position = posInicial;
		target = jugador.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		target = jugador.transform.position;
		float dist = Vector3.Distance(jugador.transform.position, transform.position);
		if(jugador.GetComponent<Animator>().GetBool("caminando") || dist > distanciaConElJugador) {
		transform.position  = Vector3.SmoothDamp(transform.position,target, ref velocidad,tiempoDeSuavizado,maxSpeed);
	} 
	}
	
}
