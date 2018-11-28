using System;
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


    private Inventario inventario;
	private AdministradorDeMisiones administradorDeMisiones;

	public int oro = 0;

	public int salud = 50;
	public int hambre = 75;

	public Item pollo;

	void Awake(){
		Assert.IsNotNull(mapaInicial);
		if(jugador == null) {
			jugador = this;
		    DontDestroyOnLoad(gameObject);
		} else if (jugador != this) {
			Destroy(gameObject);
		}
	}

    public void UsarItem(Item itemPrefab)
    {
        if(itemPrefab.consumible){
			SumarVida(itemPrefab.puntosDeVida);
			SumarEnergia(itemPrefab.puntosDeHambre);	
		}
    }

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		salud = 50;
		hambre = 75;
		
		estadoDelJugador = EstadoDelJugador.Jugando;
		
		//administradorDeMisiones.SetPollo(Object.Instantiate(pollo));
		
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
		

		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Inventario.instance.UsarItemEnLaPosicion(1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			Inventario.instance.UsarItemEnLaPosicion(2);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			Inventario.instance.UsarItemEnLaPosicion(3);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			Inventario.instance.UsarItemEnLaPosicion(4);
		}
		if(Input.GetKeyDown(KeyCode.Alpha5)){
			Inventario.instance.UsarItemEnLaPosicion(5);
		}
		if(Input.GetKeyDown(KeyCode.Alpha6)){
			Inventario.instance.UsarItemEnLaPosicion(6);
		}
		if(Input.GetKey(KeyCode.C)){
			this.speed = 8f;
		}else{
			this.speed = 3f;
		}
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



	public GameObject GetMapa(){
		return this.mapaInicial;
	}

	public int GetOro(){
		return this.oro;
	}
	public void AgregarOro(int oroAAgregar){
		this.oro += oroAAgregar;
	}

	public void RestarOro(int oroARestar){
		this.oro -= oroARestar;
	}

	public void AdquirirItem(Item item){
		Inventario.instance.AgregarItem(item);
	}

	public int GetVida(){
		return salud;
	}

	public int GetEnergia()
    {
        return hambre;
    }

	public void RestarEnergia(int energiaARestar){
		this.hambre -= energiaARestar;
		GameObject.FindGameObjectWithTag("BarraDeEnergia").GetComponent<EnergiaCtrl>().ActualizarEnergia();
	}
	public void SumarEnergia(int energiaASumar){
		this.hambre += energiaASumar;
		GameObject.FindGameObjectWithTag("BarraDeEnergia").GetComponent<EnergiaCtrl>().ActualizarEnergia();
	}

	public void RestarVida(int vidaARestar){
		this.salud -= vidaARestar;
		GameObject.FindGameObjectWithTag("BarraDeVida").GetComponent<VidaCtrl>().ActualizarVida();
	}

	public void SumarVida(int vidaASumar){
		this.salud += vidaASumar;
		GameObject.FindGameObjectWithTag("BarraDeVida").GetComponent<VidaCtrl>().ActualizarVida();
	}
	
}
