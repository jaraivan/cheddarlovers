using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour {

	public static UICtrl UI;

    void Awake(){
		
		if(UI == null) {
			UI = this;
		    DontDestroyOnLoad(gameObject);
		} else if (UI != this) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		this.ActualizarOroEnUI();
	}

	void ActualizarOroEnUI(){
		int oroDeLucas = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().GetOro();
		GameObject.FindGameObjectWithTag("TextoOro").GetComponent<Text>().text = oroDeLucas.ToString();
	}
}
