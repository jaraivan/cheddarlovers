
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public enum EstadoDeMision {Activa,Disponible,Completada,Inactiva,Entregada};
[CreateAssetMenu(fileName = "NuevaMision",menuName = "AdministradorDeMisiones/Mision")]
public class Mision : ScriptableObject  {

    public string nombreDeMision;

    public string propietario;
    public string destinatario;
    public Dialogo dialogoInicio;
    public Dialogo dialogoFin;
    public Item recompensa = null;
    public Item condicion = null;
    public int condicionOro = 0;
    public int recompensaOro = 0;

    public EstadoDeMision estadoDeMision;
    public Item precompensa = null;
    public int precompensaOro = 0;

    public Mision proxMision;

    public string descripcion;

}