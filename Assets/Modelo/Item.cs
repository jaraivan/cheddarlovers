
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NuevoItem",menuName = "Inventario/Item")]
public class Item : ScriptableObject
{
public string nombreDeItem = "Nuevo Item";
public Sprite icono = null;
public bool vendible = false;
public bool consumible = false;
public bool comprable = false;
public string descripcion = "nuevaDescripcion";
public int precio = 0;

}