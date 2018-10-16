using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CamaraSeguirCtrl : MonoBehaviour {

	public float tiempoDeSuavizado = 0.5f;
	
	private GameObject jugador;
	Transform target;
	float tLX,tLY,bRX,bRY;
	Vector2 velocidad;
	// Use this for initialization

	void Awake(){
		jugador = GameObject.FindWithTag("Player");
		 Assert.IsNotNull(jugador);
		
		this.SetLimites(jugador.gameObject.GetComponent<JugadorCtrl>().GetMapa());
		 
		
		
	}
	void Start () {
		Assert.IsNotNull(jugador);
		 transform.position = new Vector3(jugador.GetComponent<Transform>().position.x,
			jugador.GetComponent<Transform>().position.y,
			transform.position.z); 
			
			
		
	}
	
	// Update is called once per frame
	void Update () {
		//print(jugador.GetComponent<Transform>().position.y);
	}

	void FixedUpdate(){
		//GameObject jugador = GameObject.FindWithTag("Player");
		

		float posX = Mathf.Round(
			Mathf.SmoothDamp(transform.position.x,
			jugador.GetComponent<Transform>().position.x,ref velocidad.x,
			tiempoDeSuavizado
			) * 100
			) /100;

		float posY = Mathf.Round(
		Mathf.SmoothDamp(transform.position.y,
		jugador.GetComponent<Transform>().position.y,ref velocidad.y,
		tiempoDeSuavizado
		) * 100
		) /100;
		


		//Vector3 posicionJugador = jugador.GetComponent<Transform>().position;
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
