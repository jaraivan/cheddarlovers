
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NuevoDialogo",menuName = "AdministradorDeMisiones/Dialogo")]
public class Dialogo :ScriptableObject
{

    public string nombreNPC;

    public List<string> lineasDeTexto = new List<string>();
    //private int cantidadDeLineasCargadas = 0;
    // Use this for initialization

    public Dialogo(string nombreNPCQueMePasan)
    {
        nombreNPC = nombreNPCQueMePasan;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<string> GetLineasDeTexto(){
        return this.lineasDeTexto;
    }

    /* public int CantidadDeLineasDeTexto(){
        return this.cantidadDeLineasCargadas;
    } */

}