using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inactiva : IEstadoDeMision
{

    public Inactiva(){

    }

    public bool estaActiva()
    {
        return false;
    }

    public bool estaCompletada()
    {
        return false;
    }

    public bool estaEntregada()
    {
        return false;
    }

    public bool estaInactiva()
    {
        return true;
    }
}