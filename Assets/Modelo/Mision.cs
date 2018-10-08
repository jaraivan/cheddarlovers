
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision {

    public string nombreDeMision;
    public Dialogo dialogo;
    
    
	public Mision(string nombreDeMisionQueMeDan, Dialogo dialogoQueMeDan ) {
        this.nombreDeMision = nombreDeMisionQueMeDan;
        this.dialogo = dialogoQueMeDan;
	}

    // Use this for initialization
    public void Start(){

    }

    public Dialogo GetDialogo(){
        return this.dialogo;
    }
	

}