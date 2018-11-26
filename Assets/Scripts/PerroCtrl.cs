using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PerroCtrl : MonoBehaviour {
	
	private GameObject jugador;
	public float tiempoDeSuavizado = 0.5f;
	public float maxSpeed;
	public float distanciaConElJugador;
	Vector3 posInicial;
	Vector3 velocidad;
	public Vector3 target;
	public Vector2 mov;
	Animator anim;
	private Rigidbody2D rb2d;
	public float speed = 3f;

	// Use this for initialization

	void Start () {
		jugador = GameObject.FindWithTag("Player");
		anim = GetComponent<Animator>();
		posInicial = new Vector3(jugador.transform.position.x -1f,jugador.transform.position.y,transform.position.z);
		transform.position = posInicial;
		rb2d = GetComponent<Rigidbody2D>();
		target = new Vector3(jugador.transform.position.x -1f,jugador.transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		target = new Vector3(jugador.transform.position.x -1f,jugador.transform.position.y,transform.position.z);
		
		if(Mathf.Round(target.x)  == Mathf.Round(transform.position.x) && Mathf.Round(target.y) == Mathf.Round(transform.position.y)){
			anim.SetFloat("movX",0);
			anim.SetFloat("movY",0);
			anim.SetBool("caminando",false);
		}else{

		
		float distEnX = Vector2.Distance(new Vector2(transform.position.x,0),new Vector2(target.x,0));
		float distEnY = Vector2.Distance(new Vector2(0,transform.position.y),new Vector2(0,target.y));
		
		if(target.x < transform.position.x){
			distEnX = -distEnX;
		}

		if(target.y < transform.position.y){
			distEnY = -distEnY;
		}
		mov = new Vector2(
			distEnX,
			distEnY
		);
		print(mov);
		
		anim.SetBool("caminando",true);
		anim.SetFloat("movX",mov.x);
		anim.SetFloat("movY",mov.y);
		

		}
		
	}

	void FixedUpdate(){
		transform.position  = Vector3.SmoothDamp(transform.position,target, ref velocidad,tiempoDeSuavizado,maxSpeed);

		
	}
	
}
