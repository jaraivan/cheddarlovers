using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro2Ctrl : MonoBehaviour {

	private AudioSource ladrido;

	int contador = 0;

	// Use this for initialization
	void Start () {
		ladrido = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			if(contador == 0) {
				PrenderGlobo();
				contador++;
				return;
			}
			if(contador == 1) {
				ladrido.Play();
				contador++;
			}
			if(contador == 2) {
				SceneManager.LoadScene("CiudadEscena");
			}
		}
	}

	void PrenderGlobo() {
		transform.Find("globo").gameObject.SetActive(true);
	}
}
