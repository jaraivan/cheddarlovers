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

	public static JugadorCtrl jugador;

	private Mision[] misionesAgregadas;
	private int cantidadDeMisionesAgregadas = 0;

	void Awake(){
		Assert.IsNotNull(mapaInicial);
		if(jugador == null) {
			jugador = this;
		    DontDestroyOnLoad(gameObject);
		} else if (jugador != this) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		Camera.main.GetComponent<CamaraSeguirCtrl>().SetLimites(mapaInicial);
		estadoDelJugador = EstadoDelJugador.Jugando;
		misionesAgregadas = new Mision[5];
		print(misionesAgregadas.Length);
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

	public void IniciarConversacion(){
		this.estadoDelJugador = EstadoDelJugador.Conversando;
	}
	public void IniciarJugando(){
		this.estadoDelJugador = EstadoDelJugador.Jugando;
	}

	public EstadoDelJugador GetEstadoDelJugador(){
		return this.estadoDelJugador;
	}

	public void AgregarMision(Mision mision){
		misionesAgregadas[cantidadDeMisionesAgregadas] = mision;
		cantidadDeMisionesAgregadas++;
	}

	public Mision[] GetMisionesDelJugador(){
		return this.misionesAgregadas;
	}

	
}
