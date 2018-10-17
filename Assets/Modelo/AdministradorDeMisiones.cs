
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDeMisiones
{

    private Queue<Mision> misiones;

    public AdministradorDeMisiones(){
        misiones = new Queue<Mision>();
        CrearPrimeraMisionDP();
    }

    public void AgregarMision(Mision mision){
     this.misiones.Enqueue(mision);
    }

    public Mision GetMisionParaMi(string nombreNPC){
        
        foreach (Mision m in this.misiones)
        {
            if(m.GetPropietario() == nombreNPC && m.GetEstado().estaDisponible()){
                return m;
            }
        }
        return null;
    }

    
	void CrearPrimeraMisionDP(){

		Dialogo dialogo = new Dialogo("Doña Paulina");

		dialogo.AgregarLineaDeTextoLucas("Hola Doña Paulina");
		dialogo.AgregarLineaDeTextoNPC("Hola Lucas, te veo preocupado pequeño, ¿Qué ha pasado?");
		dialogo.AgregarLineaDeTextoLucas("Me acabo de enterar que mi padre tenía deudas, y me van sacar la casa si no les doy el dinero que quieren… Desde el accidente en la mina, no he conseguido trabajo, no se que voy a hacer!");
		dialogo.AgregarLineaDeTextoNPC("Oh no que terrible! Me encantaría poder ayudarte, pero ahora mismo, no se me ocurre como…");
		dialogo.AgregarLineaDeTextoNPC("Un momento, si haces algunos mandados para mi, podría darte unas monedas, no es mucho, pero por algo se empieza no?");
		dialogo.AgregarLineaDeTextoLucas("Gracias! Dime que tengo que hacer");
		dialogo.AgregarLineaDeTextoNPC("Ando necesitando algunas cosas del mercado, puedes ir a comprarlos y traerlos? Aquí tienes la lista de lo que necesito y el oro para eso…");
		Mision mision = new Mision("Haciendo mandados a Doña Paulina",dialogo,"DoniaPaulina");
		AgregarMision(mision);
	}


    public void ActivarMision(Mision mision){
        mision.SetEstado(new Activa());
        GameObject.FindGameObjectWithTag("ListaMisiones").GetComponent<ListaMisionesCtrl>().AgregarNuevaMision(mision);
        this.misiones.Dequeue();
    }

    
}