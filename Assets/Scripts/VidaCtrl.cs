using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaCtrl : MonoBehaviour {

	// Use this for initialization
	private Image vida;
	void Start () {
		vida = GetComponent<Image>();
		ActualizarVida();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActualizarVida(){
		int vidaDeLucas = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().GetVida();
		vida.fillAmount = (float ) vidaDeLucas/100f;
	}
}
