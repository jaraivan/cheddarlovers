using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendedorCtrl : MonoBehaviour {

	// Use this for initialization
	private GameObject mercadoUI;

	void Awake(){

		mercadoUI = GameObject.FindGameObjectWithTag("UI").transform.Find("Mercado").gameObject;
		
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.Space))){
			mercadoUI.SetActive(true);
			//mercadoUI.transform.position = Camera.main.GetComponent<Transform>().position;
		}
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.Space))){
			mercadoUI.SetActive(true);
			//mercadoUI.transform.position = Camera.main.GetComponent<Transform>().position;
		}
    }

	void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
			mercadoUI.SetActive(false);
		}
    }
}
