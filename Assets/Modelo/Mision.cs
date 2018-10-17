
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mision {

    public string nombreDeMision;

    public string propietario;
    public Dialogo dialogo;
    private Item recompensa = null;

    private IEstadoDeMision estadoDeMision;

    
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

    public IEstadoDeMision GetEstado(){
        return this.estadoDeMision;
    }

    public void SetEstado(IEstadoDeMision estado){
        this.estadoDeMision = estado;
    }
    public string GetPropietario(){
        return this.propietario;
    }

}