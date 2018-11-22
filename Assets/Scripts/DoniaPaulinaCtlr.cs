using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoniaPaulinaCtlr : MonoBehaviour
{
    private GameObject conversacion;
    //private Queue<string> conversacionActual;
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
    void Start()
    {
        //conversacionActual = new Queue<string>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        if(this.MeHablaElJugadorEnEstadoJugando(col)){
            this.ComportamientoJugando(col);
        }
        if(this.MeHablaElJugadorEnEstadoConversando(col)){
        this.ComportamientoConversando(col);
        }

        
    }

     void OnTriggerEnter2D(Collider2D col)
    {
        if(this.MeHablaElJugadorEnEstadoJugando(col)){
            this.ComportamientoJugando(col);
        }
        if(this.MeHablaElJugadorEnEstadoConversando(col)){
        this.ComportamientoConversando(col);
        }
    
    }

    void OnTriggerExit2D(Collider2D col){
        this.DesactivarConversacion(null);
    }
    void ActivarConversacionNPC()
    {
        conversacion.SetActive(true);
        this.misionActual = AdministradorDeMisiones.instance.GetMisionParaMi("DoniaPaulina");
        
        if (this.misionActual == null)
        {
            this.dialogoActual = dialogoSinMision;
            //conversacion.GetComponentInChildren<Text>().text = "No tengo misiones para ti";

        }
        else
        {
            if(this.misionActual.estadoDeMision == EstadoDeMision.Disponible){
            //this.conversacionActual = CopiarConversacion2(this.misionActual.GetDialogoInicio().GetLineasDeTexto2());
            this.dialogoActual = misionActual.dialogoInicio;
            }else{

            if(this.misionActual.estadoDeMision == EstadoDeMision.Activa && this.CumpleCondicionDeMision(misionActual)){
            //this.conversacionActual = CopiarConversacion2(this.misionActual.GetDialogoFin().GetLineasDeTexto2());
            this.dialogoActual = misionActual.dialogoFin;
            }

            if(this.misionActual.estadoDeMision == EstadoDeMision.Activa  && !this.CumpleCondicionDeMision(misionActual)){
                //conversacion.GetComponentInChildren<Text>().text = "No tenes lo que te pido";
                this.dialogoActual = dialogoSinCondicion;
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
            dialogoActual = dialogoSinMision;
        }
        if (mision != null && mision.estadoDeMision == EstadoDeMision.Activa && !this.CumpleCondicionDeMision(mision))
        {
            //AdministradorDeMisiones.instance.Completar(mision);
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
        //leyendoLinea++;
        //ComportamientoConversando2(col);
        
    }


    void ComportamientoConversando(Collider2D col)
    {
        
        if (this.leyendoLinea == this.dialogoActual.lineasDeTexto.Count){
            this.DesactivarConversacion(this.misionActual);
        }
        else{
            conversacion.GetComponentInChildren<Text>().text = this.dialogoActual.lineasDeTexto[leyendoLinea];
            leyendoLinea++;
        }
        
    }

    bool MeHablaElJugadorEnEstadoJugando(Collider2D col){
        return (col.gameObject.tag == "Player"
        && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Jugando && (Input.GetKeyDown(KeyCode.Space)));
    }

    bool MeHablaElJugadorEnEstadoConversando(Collider2D col){
        return (col.gameObject.tag == "Player"
        && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Conversando
        && (Input.GetKeyDown(KeyCode.Space)));
    }

    bool CumpleCondicionDeMision(Mision mision){
        
        return Inventario.instance.TieneElItem(mision.condicion);
    }

}
