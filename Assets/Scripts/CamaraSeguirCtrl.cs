using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguirCtrl : MonoBehaviour {

	public GameObject jugador;
	private Rigidbody2D rb2dJugador;
	Transform target;
	float tLX,tLY,bRX,bRY;
	// Use this for initialization
	void Start () {
		rb2dJugador = jugador.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Vector3 posicionJugador = rb2dJugador.position;
		transform.position = new Vector3(
			Mathf.Clamp(posicionJugador.x,tLX,bRX),
			Mathf.Clamp(posicionJugador.y,bRY,tLY),
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
