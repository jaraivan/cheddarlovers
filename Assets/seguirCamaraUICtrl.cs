using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirCamaraUICtrl : MonoBehaviour {
	public Camera camara;
	private Transform transformDeLaCamara;
	public float distanciaY = 3.3f;
	
	// Use this for initialization
	void Start () {
		transformDeLaCamara = camara.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transformDeLaCamara.position.x,transformDeLaCamara.position.y-distanciaY,transform.position.z);
	}
}
