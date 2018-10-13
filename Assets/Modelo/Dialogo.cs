
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo 
{

    public string nombreNPC;
    private Queue<string> lineasDeTexto;
    //private int cantidadDeLineasCargadas = 0;
    // Use this for initialization

    public Dialogo(string nombreNPCQueMePasan)
    {
        // inicializo un array de 30 strings maximo
        lineasDeTexto = new Queue<string>();
        nombreNPC = nombreNPCQueMePasan;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AgregarLineaDeTextoLucas(string lineaDeTexto)
    {
        //lineasDeTexto.SetValue("Lucas: " + lineaDeTexto, cantidadDeLineasCargadas);
        lineasDeTexto.Enqueue("Lucas: " + lineaDeTexto);
        //cantidadDeLineasCargadas++;


    }
    public void AgregarLineaDeTextoNPC(string lineaDeTexto)
    {
        //lineasDeTexto.SetValue(nombreNPC + ": " + lineaDeTexto, cantidadDeLineasCargadas);
        lineasDeTexto.Enqueue(nombreNPC + ": " + lineaDeTexto);
        //cantidadDeLineasCargadas++;

    }

    public Queue<string> GetLineasDeTexto(){
        return this.lineasDeTexto;
    }

    /* public int CantidadDeLineasDeTexto(){
        return this.cantidadDeLineasCargadas;
    } */

}