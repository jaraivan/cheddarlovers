
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mision {

    public string nombreDeMision;

    public string propietario;
    public Dialogo dialogo;
    private Item recompensa = null;
    private int recompensaOro = 0;

    private IEstadoDeMision estadoDeMision;
    private Item precompensa = null;
    private int precompensaOro = 0;


    
	public Mision(string nombreDeMisionQueMeDan, Dialogo dialogoQueMeDan ,string propietarioMision) {
        this.nombreDeMision = nombreDeMisionQueMeDan;
        this.dialogo = dialogoQueMeDan;
        estadoDeMision = new Disponible();
        this.propietario = propietarioMision;
	}

    // Use this for initialization
    public void Start(){

    }

    public Dialogo GetDialogo(){
        return this.dialogo;
    }

    public string GetNombreMision(){
        return this.nombreDeMision;
    }

    public void AgregarRecompensa(Item item){
        this.recompensa = item;
    }

    public Item GetRecompensa(){
        return this.recompensa;
    }
    public Item GetPrecompensa(){
        return this.precompensa;
    }

    public IEstadoDeMision GetEstado(){
        return this.estadoDeMision;
    }

    public void SetEstado(IEstadoDeMision estado){
        this.estadoDeMision = estado;
    }
    public string GetPropietario(){
        return this.propietario;
    }

    public int GetRecompensaOro(){
        return this.recompensaOro;
    }

    public int GetPrecompensaOro(){
        return this.precompensaOro;
    }

    public void SetPrecompensaOro(int oro){
        this.precompensaOro = oro;
    }
}