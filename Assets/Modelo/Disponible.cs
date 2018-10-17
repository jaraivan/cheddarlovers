using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disponible : IEstadoDeMision
{

    public Disponible(){

    }

    public bool estaActiva()
    {
        return false;
    }

    public bool estaCompletada()
    {
        return false;
    }

    public bool estaDisponible()
    {
        return true;
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