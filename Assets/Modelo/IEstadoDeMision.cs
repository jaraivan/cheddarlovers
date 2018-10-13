using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEstadoDeMision
{
    bool estaInactiva();
    bool estaActiva();
    bool estaCompletada();
    bool estaEntregada();
} 
