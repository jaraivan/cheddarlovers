using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreGatos : MonoBehaviour {

	public Sprite abierto;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col)
    { if(Input.GetKeyDown(KeyCode.Space) && col.gameObject.tag == "Player"){
                IniciarAcertijo();
        }
    }

	private void IniciarAcertijo()
    {
        GameObject.FindGameObjectWithTag("canvasGatos").transform.Find("AcertijoGatos").gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col){
        GameObject.FindGameObjectWithTag("canvasGatos").transform.Find("AcertijoGatos").gameObject.SetActive(false);
    }

    public void CambiarSpriteAbierto()
    {
        GetComponent<SpriteRenderer>().sprite = abierto;
    }
}
