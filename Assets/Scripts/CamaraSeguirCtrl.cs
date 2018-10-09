﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguirCtrl : MonoBehaviour {

	public float tiempoDeSuavizado = 0.5f;
	public GameObject jugador;
	private Rigidbody2D rb2dJugador;
	Transform target;
	float tLX,tLY,bRX,bRY;
	Vector2 velocidad;
	// Use this for initialization

	void Awake(){
		
	}
	void Start () {
		//rb2dJugador = 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		JugadorCtrl jugador = FindObjectOfType<JugadorCtrl>();

		float posX = Mathf.Round(
			Mathf.SmoothDamp(transform.position.x,
			jugador.GetComponent<Rigidbody2D>().position.x,ref velocidad.x,
			tiempoDeSuavizado
			) * 100
			) /100;

		float posY = Mathf.Round(
		Mathf.SmoothDamp(transform.position.y,
		jugador.GetComponent<Rigidbody2D>().position.y,ref velocidad.y,
		tiempoDeSuavizado
		) * 100
		) /100;
		


		Vector3 posicionJugador = jugador.GetComponent<Rigidbody2D>().position;
		transform.position = new Vector3(
			Mathf.Clamp(posX,tLX,bRX),
			Mathf.Clamp(posY,bRY,tLY),
			transform.position.z);
	}

	public void SetLimites(GameObject map){
		Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap>();
		float camaraSize = Camera.main.orthographicSize;

		tLX = map.transform.position.x + camaraSize +4;
		tLY = map.transform.position.y - camaraSize;
		bRX = (map.transform.position.x + config.NumTilesWide - camaraSize -13)/2;
		bRY = (map.transform.position.y - config.NumTilesHigh + camaraSize+5)/2;
	
	}


}
