using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingotesDeOro : MonoBehaviour {

	public int valor = 3000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AgregarOro(valor);
            Destroy(gameObject);
		}
}
}
