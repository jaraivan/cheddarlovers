
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public enum EstadoDeMision {Activa,Disponible,Completada,Inactiva,Entregada};
[CreateAssetMenu(fileName = "NuevaMision",menuName = "AdministradorDeMisiones/Mision")]
public class Mision : ScriptableObject  {

    public string nombreDeMision;

    public string propietario;
    public Dialogo dialogoInicio;
    public Dialogo dialogoFin;
    public Item recompensa = null;
    public Item condicion = null;
    public int recompensaOro = 0;

    public EstadoDeMision estadoDeMision;
    public Item precompensa = null;
    public int precompensaOro = 0;


    /* 
	public Mision(string nombreDeMisionQueMeDan, Dialogo dialogoDeInicio,Dialogo dialogoDeFin ,string propietarioMision) {
        this.nombreDeMision = nombreDeMisionQueMeDan;
        this.dialogoInicio = dialogoDeInicio;
        this.dialogoFin = dialogoDeFin;
        estadoDeMision = new Disponible();
        this.propietario = propietarioMision;
	} */

    // Use this for initialization
    public void Start(){

    }

    public Dialogo GetDialogoInicio(){
        return this.dialogoInicio;
    }
    public Dialogo GetDialogoFin(){
        return this.dialogoFin;
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

   /*  public IEstadoDeMision GetEstado(){
        return this.estadoDeMision;
    }

    public void SetEstado(IEstadoDeMision estado){
        this.estadoDeMision = estado;
    } */
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

    public void SetItemCondicion(Item item){
        this.condicion = item;
    }

    public Item GetItemCondicion(){
        return this.condicion;
    }
}