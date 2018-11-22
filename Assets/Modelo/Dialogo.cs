
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NuevoDialogo",menuName = "AdministradorDeMisiones/Dialogo")]
public class Dialogo :ScriptableObject
{
    public string nombreNPC;
    public List<string> lineasDeTexto = new List<string>();
 
}