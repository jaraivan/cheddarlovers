using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Completada : IEstadoDeMision{

    public Completada(){

    }

    public bool estaActiva()
    {
        return false;
    }

    public bool estaCompletada()
    {
        return true;
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