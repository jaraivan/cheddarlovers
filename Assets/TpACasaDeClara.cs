﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpACasaDeClara : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("CasaDeClara");
		}
}
}