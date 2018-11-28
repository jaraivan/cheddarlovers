using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PescadorCtrl : MonoBehaviour
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
            if(AdministradorDeMisiones.instance.GetMisionParaMi(this.nombreNpc) != null){
            if(this.MeHablaElJugadorEnEstadoJugando(col)){
                this.ComportamientoJugando(col);
                return;
            }

            if(this.MeHablaElJugadorEnEstadoConversando(col)){
            this.ComportamientoConversando(col);
            return;
            }

            }else{
                IniciarAcertijo();
            }
        }
    }

    private void IniciarAcertijo()
    {
        GameObject.FindGameObjectWithTag("UI").transform.Find("Acertijo").gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col){
        this.DesactivarConversacion(null);
        GameObject.FindGameObjectWithTag("UI").transform.Find("Acertijo").gameObject.SetActive(false);
    }
    void ActivarConversacionNPC()
    {
        conversacion.SetActive(true);
        this.misionActual = AdministradorDeMisiones.instance.GetMisionParaMi(this.nombreNpc);
        
        this.dialogoActual = GetDialogoCorrespondienteAMisionActual();
        
    }

    private Dialogo GetDialogoCorrespondienteAMisionActual(){
        if (this.misionActual == null){
            return dialogoSinMision;
        }
            
        if(this.misionActual.estadoDeMision == EstadoDeMision.Disponible){
            return misionActual.dialogoInicio;
        }

        if(this.misionActual.estadoDeMision == EstadoDeMision.Activa && this.CumpleCondicionDeMision(misionActual)){
            return misionActual.dialogoFin;
        }

        if(this.misionActual.estadoDeMision == EstadoDeMision.Activa  && !this.CumpleCondicionDeMision(misionActual)){
            return dialogoSinCondicion;
        }
                
        return dialogoSinMision;    
    }


    void DesactivarConversacion(Mision mision)
    {
        JugadorCtrl lucas = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>();

        lucas.IniciarJugando();
        if (mision != null && mision.estadoDeMision == EstadoDeMision.Disponible)
        {
            AdministradorDeMisiones.instance.ActivarMision(mision);
            conversacion.SetActive(false);
            leyendoLinea = 0;
            return;
            
        }
        if (mision != null && mision.estadoDeMision == EstadoDeMision.Activa && this.CumpleCondicionDeMision(mision))
        {
            if(!dialogoActual == mision.dialogoFin){
            dialogoActual = mision.dialogoFin;
            AdministradorDeMisiones.instance.Completar(mision);
            leyendoLinea = 0;
            lucas.IniciarConversacion();
            ComportamientoConversandoFinDeMision();

            }else{
                AdministradorDeMisiones.instance.Completar(mision);
                conversacion.SetActive(false);
            leyendoLinea = 0;
            }
            return;
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

     void ComportamientoConversandoFinDeMision()
    {
        if (this.leyendoLinea >= this.dialogoActual.lineasDeTexto.Count){
            conversacion.SetActive(false);
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
        return CumpleSoyElDestinario(mision) && CumpleTengoElItemPedido(mision) && CumpleTengoElOroPedido(mision);
    }

    bool CumpleSoyElDestinario(Mision mision){
        return  mision.destinatario == this.nombreNpc;
    }

    bool CumpleTengoElItemPedido(Mision mision){
        return Inventario.instance.TieneElItem(mision.condicion);
    }

    bool CumpleTengoElOroPedido(Mision mision){
        return GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().GetOro() >= mision.condicionOro;
    }

}
