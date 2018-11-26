using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaCtrl : MonoBehaviour {

	// Use this for initialization
	private Image energia;
	void Start () {
		energia = GetComponent<Image>();
		ActualizarEnergia();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActualizarEnergia(){
		int energiaDeLucas = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().GetEnergia();
		energia.fillAmount = (float ) energiaDeLucas/100f;
	}
}
