using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpACiudad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("CiudadEscena");
			Transform jugadorT = GameObject.FindWithTag("Player").GetComponent<Transform>();
			Camera.main.transform.position = new Vector3(jugadorT.position.x,jugadorT.position.y,transform.position.z);
		}
}
}
