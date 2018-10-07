using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoñaPaulinaCtlr : MonoBehaviour {

	public GameObject lucas;
	public GameObject conversacion;
	private BoxCollider2D bc2d;
	// Use this for initialization
	void Start () {
		bc2d = GetComponent<BoxCollider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			if(Input.GetKeyDown(KeyCode.Space)){
				print("Hola Lucas, soy Doña Paulina");
				ActivarConversacion();
				conversacion.GetComponentInChildren<Text>().text = "Hola Lucas, soy Doña Paulina";
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			if(Input.GetKeyDown(KeyCode.Space)){
				print("Hola Lucas, soy Doña Paulina");
				ActivarConversacion();
				conversacion.GetComponentInChildren<Text>().text = "Hola Lucas, soy Doña Paulina";
			}
		}
	}
	void ActivarConversacion(){
		conversacion.SetActive(true);
	}
}
