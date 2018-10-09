using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpACiudad : MonoBehaviour {

	private BoxCollider2D col;


	// Use this for initialization
	void Start () {
		col = GetComponent<BoxCollider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player") {
            SceneManager.LoadScene("CiudadEscena");
		}
}
}
