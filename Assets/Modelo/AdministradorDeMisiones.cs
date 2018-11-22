
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdministradorDeMisiones : MonoBehaviour{
     #region Singleton
    public static AdministradorDeMisiones instance;
    

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Mas de una instancia del AdministradorDeMisiones");
            return;
        }
        instance = this;
        //CrearPrimeraMisionDP();
    }
    #endregion

    //public Queue<Mision> misiones = new Queue<Mision>();
    public List<Mision> misiones2 = new List<Mision>();
    public Item pollo;
    public Mision mision1;

  /*   public AdministradorDeMisiones(Item pollo1){
        misiones = new Queue<Mision>();
        CrearPrimeraMisionDP();
        this.pollo = pollo1;
    } */

    void Start(){
       this.AgregarMision(mision1);
        
    }

    public void AgregarMision(Mision mision){
     //this.misiones.Enqueue(mision);
     this.misiones2.Add(mision);
    }

    public Mision GetMisionParaMi(string nombreNPC){
        
        foreach (Mision m in this.misiones2)
        {
            if((m.propietario == nombreNPC && m.estadoDeMision == EstadoDeMision.Activa) ||  (m.propietario == nombreNPC && m.estadoDeMision == EstadoDeMision.Disponible)){
                return m;
            }
        }
        return null;
    }

    
/* 	void CrearPrimeraMisionDP(){

		Dialogo dialogoInicio = new Dialogo("Doña Paulina");

		dialogoInicio.AgregarLineaDeTextoLucas("Hola Doña Paulina");
		dialogoInicio.AgregarLineaDeTextoNPC("Hola Lucas, te veo preocupado pequeño, ¿Qué ha pasado?");
		dialogoInicio.AgregarLineaDeTextoLucas("Me acabo de enterar que mi padre tenía deudas, y me van sacar la casa si no les doy el dinero que quieren… Desde el accidente en la mina, no he conseguido trabajo, no se que voy a hacer!");
		dialogoInicio.AgregarLineaDeTextoNPC("Oh no que terrible! Me encantaría poder ayudarte, pero ahora mismo, no se me ocurre como…");
		dialogoInicio.AgregarLineaDeTextoNPC("Un momento, si haces algunos mandados para mi, podría darte unas monedas, no es mucho, pero por algo se empieza no?");
		dialogoInicio.AgregarLineaDeTextoLucas("Gracias! Dime que tengo que hacer");
		dialogoInicio.AgregarLineaDeTextoNPC("Ando necesitando algunas cosas del mercado, puedes ir a comprarlos y traerlos? Aquí tienes la lista de lo que necesito y el oro para eso…");
		Dialogo dialogoFin = new Dialogo("Doña Paulina");
        dialogoFin.AgregarLineaDeTextoLucas("Aqui tengo tu pollo");
        dialogoFin.AgregarLineaDeTextoNPC("Gracias, aqui tienes la recompensa!");
        Mision mision = new Mision("Haciendo mandados a Doña Paulina",dialogoInicio,dialogoFin,"DoniaPaulina");
        
        mision.SetPrecompensaOro(5);
        mision.SetItemCondicion(this.pollo);
		this.AgregarMision(mision);
	} */

/*     void CrearSegundaMisionDP(){

		Dialogo dialogoInicio = new Dialogo("Doña Paulina");

		dialogoInicio.AgregarLineaDeTextoNPC("Muchas gracias, ya sabes los años pasan y ya no es tan fácil para mi una cosa tan simple como ir al mercado, le hubiese pedido a mi nieta Clara que lo haga, pero ella no se siente muy bien.");
		dialogoInicio.AgregarLineaDeTextoLucas("Que tiene?");
		dialogoInicio.AgregarLineaDeTextoNPC("Le agarró un resfrío, nada grave, le haré mi sopa secreta curativa, y ya se sentirá bien otra vez");
		dialogoInicio.AgregarLineaDeTextoNPC("Que vieja tonta que soy,  olvidé anotar algo en la lista , sería mucha molestia que vayas a buscar algo mas por mí?");
		dialogoInicio.AgregarLineaDeTextoLucas("No hay problema, dime.");
		dialogoInicio.AgregarLineaDeTextoNPC("Necesito que me consigas unas hojas de una planta particular, ve junto a la iglesia, al sur del pueblo y busca una que tenga unas flores rosadas");
		Dialogo dialogoFin = new Dialogo("Doña Paulina");
        Mision mision = new Mision("Le entregas lo q te pidió que le compres",dialogoInicio,dialogoFin,"DoniaPaulina");
        
		AgregarMision(mision);
	} */


    public void ActivarMision(Mision mision){
        mision.estadoDeMision = EstadoDeMision.Activa;
        GameObject.FindGameObjectWithTag("UI").transform.Find("ListaMisiones").gameObject.GetComponent<ListaMisionesCtrl>().AgregarNuevaMision(mision);
        int oroAAgregar = mision.GetPrecompensaOro();
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AgregarOro(oroAAgregar);
        //this.misiones.Dequeue();
    }


    public void SetPollo(Item item){
        this.pollo = item;
    }

    public void Completar(Mision mision){
        mision.estadoDeMision= EstadoDeMision.Completada;
        GameObject.FindGameObjectWithTag("UI").transform.Find("ListaMisiones").gameObject.GetComponent<ListaMisionesCtrl>().QuitarMisionCompletada(mision);
        int oroAAgregar = mision.GetRecompensaOro();
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AgregarOro(oroAAgregar);
        Item recompensaItem = mision.GetRecompensa();
        //GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AdquirirItem(recompensaItem);

    }
    
}