using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorMision : MonoBehaviour {

	public Item florRosa;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col) {
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
			Inventario.instance.AgregarItem(florRosa);
		}
	}
}
