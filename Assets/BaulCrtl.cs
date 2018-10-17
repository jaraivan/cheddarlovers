using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum EstadoDelBaul{Abierto, Cerrado};
public class BaulCrtl : MonoBehaviour {

	private EstadoDelBaul estadoDelBaul = EstadoDelBaul.Cerrado;

	private BoxCollider2D col;

	private Animator anim;
	private Animator mantenerAbierto;
	private Animator cerrarBaul;
	private Animator idle;

	// Use this for initialization
	void Start () {
		col = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
		mantenerAbierto = GetComponent<Animator>();
		cerrarBaul = GetComponent<Animator>();
        idle = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
            AbrirBaul();
			mantenerAbierto.SetBool("mantenerbaulAbierto", true);
			
		}
}
    
void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
            AbrirBaul();
			mantenerAbierto.SetBool("mantenerbaulAbierto", true);
			
		}
		
}

void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player") {
             cerrarBaul.SetBool("cerrarBaul", true);
			 mantenerAbierto.SetBool("mantenerbaulAbierto", false);
			 anim.SetBool("apretaronParaAbrir", false);
			 
		}
}

	void AbrirBaul() {
		anim.SetBool("apretaronParaAbrir", true);
		cerrarBaul.SetBool("cerrarBaul", false);
	}

}
