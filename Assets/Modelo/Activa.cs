using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activa : IEstadoDeMision{

    public Activa(){

    }

    public bool estaActiva()
    {
        return true;
    }

    public bool estaCompletada()
    {
        return false;
    }

    public bool estaDisponible()
    {
        return false;
    }

    public bool estaEntregada()
    {
        return false;
    }

    public bool estaInactiva()
    {
        return false;
    }
}