using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public enum EstadoDelJugador{Conversando,Jugando};

public class JugadorCtrl : MonoBehaviour {

	public GameObject mapaInicial;
	public float speed = 3f;
	private Rigidbody2D rb2d;
	private Animator anim;
	private Vector2 mov;

	public bool quiereHablar = false;
	private EstadoDelJugador estadoDelJugador = EstadoDelJugador.Jugando;

	void Awake(){
		Assert.IsNotNull(mapaInicial);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		Camera.main.GetComponent<CamaraSeguirCtrl>().SetLimites(mapaInicial);
		estadoDelJugador = EstadoDelJugador.Jugando;
	}
	
	// Update is called once per frame
	void Update () {
		mov = new Vector2(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical")
		);
		if(mov != Vector2.zero){
		anim.SetFloat("movX",mov.x);
		anim.SetFloat("movY",mov.y);
		anim.SetBool("caminando",true);
		}else{
			anim.SetBool("caminando",false);
		}

		

	}

	void FixedUpdate(){
		rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);


	}

	
}
