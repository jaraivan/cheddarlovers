using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum EstadoDelBaul{Abierto, Cerrado};
public class BaulCrtl : MonoBehaviour {

	private EstadoDelBaul estadoDelBaul = EstadoDelBaul.Cerrado;

	private BoxCollider2D col;

	private Animator anim;

	// Use this for initialization
	void Start () {
		col = GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
            AbrirBaul();
		}
}
    
	void AbrirBaul() {
		
	}

}
