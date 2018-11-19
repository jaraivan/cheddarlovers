
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario 
{
private List<Item> items;

    public Inventario(){
        this.items = new List<Item>();
    }

    public void AgregarItem(Item item){
        this.items.Add(item);
    }


}