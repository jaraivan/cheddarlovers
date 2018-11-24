using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuCtrl : MonoBehaviour {

  private AudioSource musica;

	// Use this for initialization
	void Start () {
		musica = GetComponent<AudioSource>();
		musica.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CambiarEscena(string nombreS) {
		SceneManager.LoadScene(1);
		musica.Stop();
	}
}
