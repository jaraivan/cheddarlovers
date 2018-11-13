using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoniaPaulinaCtlr : MonoBehaviour
{
    private GameObject conversacion;
    private Queue<string> conversacionActual;
    private Mision misionActual;

    // Use this for initialization

    void Awake(){
        conversacion = GameObject.FindGameObjectWithTag("UI").transform.Find("Conversacion").gameObject;

    }
    void Start()
    {
        conversacionActual = new Queue<string>();


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
        this.misionActual = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().GetAdministradorDeMisiones().GetMisionParaMi("DoniaPaulina");
        if (this.misionActual == null)
        {
            conversacion.GetComponentInChildren<Text>().text = "No tengo misiones para ti";

        }
        else
        {
            this.conversacionActual = CopiarConversacion(this.misionActual.GetDialogo().GetLineasDeTexto());
            


        }
    }

    void DesactivarConversacion(Mision mision)
    {
        JugadorCtrl lucas = GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>();

        lucas.IniciarJugando();
        if (mision != null)
        {
            lucas.GetAdministradorDeMisiones().ActivarMision(mision);
        }
        conversacion.SetActive(false);
    }

    Queue<string> CopiarConversacion(Queue<string> queueQueMePasan)
    {
        Queue<string> nuevaQueue = new Queue<string>();

        foreach (string e in queueQueMePasan)
        {
            nuevaQueue.Enqueue(e);
        }

        return nuevaQueue;
    }

    void ComportamientoJugando(Collider2D col)
    {
        col.gameObject.GetComponent<JugadorCtrl>().IniciarConversacion();
        ActivarConversacionNPC();
        conversacion.GetComponentInChildren<Text>().text = this.conversacionActual.Dequeue();
        
    }

    void ComportamientoConversando(Collider2D col)
    {
        
        if (this.conversacionActual.Count == 0){
            this.DesactivarConversacion(this.misionActual);
        }
        else{
            conversacion.GetComponentInChildren<Text>().text = this.conversacionActual.Dequeue();
        }
        
    }

    bool MeHablaElJugadorEnEstadoJugando(Collider2D col){
        return (col.gameObject.tag == "Player"
        && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Jugando
        && (Input.GetKeyDown(KeyCode.Space)));
    }

    bool MeHablaElJugadorEnEstadoConversando(Collider2D col){
        return (col.gameObject.tag == "Player"
        && col.gameObject.GetComponent<JugadorCtrl>().GetEstadoDelJugador() == EstadoDelJugador.Conversando
        && (Input.GetKeyDown(KeyCode.Space)));
    }

}
