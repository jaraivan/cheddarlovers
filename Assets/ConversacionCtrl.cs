using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversacionCtrl : MonoBehaviour {

	public float distanciaY = 3.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float posY = transform.position.y-distanciaY;
		transform.position = new Vector3(transform.position.x,posY,transform.position.z);
	}
}
