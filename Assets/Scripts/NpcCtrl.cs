using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcCtrl : MonoBehaviour
{
    public string nombreNpc;
    private GameObject conversacion;
    public Dialogo dialogoActual;
    public Dialogo dialogoSinMision;
    public Dialogo dialogoSinCondicion;
    public int leyendoLinea = 0;
    public Mision misionActual ;
    public Item pollo;

    // Use this for initialization
    void Awake(){
        conversacion = GameObject.FindGameObjectWithTag("UI").transform.Find("Conversacion").gameObject;

    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if(Input.GetKeyDown(KeyCode.Space)){
            if(this.MeHablaElJugadorEnEstadoJugando(col)){
                this.ComportamientoJugando(col);
                return;
            }

            if(this.MeHablaElJugadorEnEstadoConversando(col)){
            this.ComportamientoConversando(col);
            return;
            }
        }
    }


    void OnTriggerExit2D(Collider2D col){
        this.DesactivarConversacion(null);
    }
    void ActivarConversacionNPC()
    {
        conversacion.SetActive(true);
        this.misionActual = AdministradorDeMisiones.instance.GetMisionParaMi(this.nombreNpc);
        
        if (this.misionActual == null)
        {
            this.dialogoActual = dialogoSinMision;

        }
        else
        {
            if(this.misionActual.estadoDeMision == EstadoDeMision.Disponible){
            this.dialogoActual = misionActual.dialogoInicio;
            }else{

                if(this.misionActual.estadoDeMision == EstadoDeMision.Activa && this.CumpleCondicionDeMision(misionActual)){
                this.dialogoActual = misionActual.dialogoFin;
                return;
                }

                if(this.misionActual.estadoDeMision == EstadoDeMision.Activa  && !this.CumpleCondicionDeMision(misionActual)){
                    this.dialogoActual = dialogoSinCondicion;
                    return;
                }
            }

        }
    }

    void DesactivarConversacion(Mision mision)
    {
        JugadorCtrl lucas = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>();

        lucas.IniciarJugando();
        if (mision != null && mision.estadoDeMision == EstadoDeMision.Disponible)
        {
            AdministradorDeMisiones.instance.ActivarMision(mision);
            
        }
        if (mision != null && mision.estadoDeMision == EstadoDeMision.Activa && this.CumpleCondicionDeMision(mision))
        {
            AdministradorDeMisiones.instance.Completar(mision);
            dialogoActual = mision.dialogoFin;
            
        }
        if (mision != null && mision.estadoDeMision == EstadoDeMision.Activa && !this.CumpleCondicionDeMision(mision))
        {
            dialogoActual = dialogoSinCondicion;
        }
        conversacion.SetActive(false);
        leyendoLinea = 0;
        
    }


    void ComportamientoJugando(Collider2D col)
    {
        col.gameObject.GetComponent<JugadorCtrl>().IniciarConversacion();
        ActivarConversacionNPC();
        conversacion.GetComponentInChildren<Text>().text = this.dialogoActual.lineasDeTexto[leyendoLinea];
        leyendoLinea++; 
    }


    void ComportamientoConversando(Collider2D col)
    {
        if (this.leyendoLinea >= this.dialogoActual.lineasDeTexto.Count){
            this.DesactivarConversacion(this.misionActual);
        }
        else{
            conversacion.GetComponentInChildren<Text>().text = this.dialogoActual.lineasDeTexto[leyendoLinea];
            leyendoLinea++;
        }
        
    }

    bool MeHablaElJugadorEnEstadoJugando(Collider2D col){
        return (col.gameObject.tag == "Player"
        && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Jugando );
    }

    bool MeHablaElJugadorEnEstadoConversando(Collider2D col){
        return (col.gameObject.tag == "Player"
        && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Conversando);
    }

    bool CumpleCondicionDeMision(Mision mision){
        if(mision.condicion == null){
            return true;
        }
        return Inventario.instance.TieneElItem(mision.condicion);
    }

}
