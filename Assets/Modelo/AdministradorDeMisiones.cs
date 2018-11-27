
using System;
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
    }
    #endregion


    public List<Mision> misiones2 = new List<Mision>();

    void Start(){
        ReiniciarTodasLasMision();
        ActivarMisionPrincipal();
        HacerDisponibleMision1();
    }

    private void HacerDisponibleMision1()
    {
        foreach (Mision m in this.misiones2)
        {
            if(m.nombreDeMision == "Ayudando a Doña Paulina"){
                m.estadoDeMision = EstadoDeMision.Disponible;
            }
        }
    }

    private void ActivarMisionPrincipal()
    {
        foreach (Mision m in this.misiones2)
        {
            if(m.nombreDeMision == "Deudas Heredadas"){
                m.estadoDeMision = EstadoDeMision.Activa;
            }
        }
    }

    private void ReiniciarTodasLasMision()
    {
        foreach (Mision m in this.misiones2)
        {
            m.estadoDeMision = EstadoDeMision.Inactiva;
        }
    
    }

    public void AgregarMision(Mision mision){
     this.misiones2.Add(mision);
    }

    public Mision GetMisionParaMi(string nombreNPC){
        foreach (Mision m in this.misiones2)
        {
            if((m.propietario == nombreNPC && m.estadoDeMision == EstadoDeMision.Activa) ||  
            (m.propietario == nombreNPC && m.estadoDeMision == EstadoDeMision.Disponible)
            || m.destinatario == nombreNPC && m.estadoDeMision == EstadoDeMision.Activa){
                return m;
            }
        }
        return null;
    }

    public List<Mision> GetMisionesActivas(){
        List<Mision> misionesActivas = new List<Mision>();

        foreach(Mision m in this.misiones2){
            if(m!=null){
                if(m.estadoDeMision == EstadoDeMision.Activa){
                    misionesActivas.Add(m);
                }
            }
        }

        return misionesActivas;
    }

    public List<Mision> GetMisionesActivasYDisponibles(){
        List<Mision> misionesActivas = new List<Mision>();

        foreach(Mision m in this.misiones2){
            if(m!=null){
                if(m.estadoDeMision == EstadoDeMision.Activa || m.estadoDeMision == EstadoDeMision.Disponible ){
                    misionesActivas.Add(m);
                }
            }
        }

        return misionesActivas;
    }

    
    public void ActivarMision(Mision mision){
        BuscarYActivarMisionEnLaLista(mision);
        GameObject.FindGameObjectWithTag("UI").transform.Find("ListaMisiones").gameObject.GetComponent<ListaMisionesCtrl>().ActualizarListaDeMisiones();
        int oroAAgregar = mision.precompensaOro;
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AgregarOro(oroAAgregar);
        if(mision.precompensa !=null){
           GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AdquirirItem(mision.precompensa); 
        }
    }

    private void BuscarYActivarMisionEnLaLista(Mision mision)
    {
        misiones2.Find(m=> m.nombreDeMision == mision.nombreDeMision).estadoDeMision = EstadoDeMision.Activa;
    }

    private void BuscarYHacerDisponibleMisionEnLaLista(Mision mision)
    {
        misiones2.Find(m=> m.nombreDeMision == mision.nombreDeMision).estadoDeMision = EstadoDeMision.Disponible;
    }

    private void BuscarYCompletarMisionEnLaLista(Mision mision)
    {
        misiones2.Find(m=> m.nombreDeMision == mision.nombreDeMision).estadoDeMision = EstadoDeMision.Completada;
    }

    public void Completar(Mision mision){
        BuscarYCompletarMisionEnLaLista(mision);
        GameObject.FindGameObjectWithTag("UI").transform.Find("ListaMisiones").gameObject.GetComponent<ListaMisionesCtrl>().ActualizarListaDeMisiones();
        
        int oroAAgregar = mision.recompensaOro;
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AgregarOro(oroAAgregar);
        Item recompensaItem = mision.recompensa;
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AdquirirItem(recompensaItem);
         if(mision.condicion != null) {
            Inventario.instance.QuitarElItemPorMision(mision.condicion);
         }
        BuscarYHacerDisponibleMisionEnLaLista(mision.proxMision);
    }

    public void Completar2(Mision mision){
        BuscarYCompletarMisionEnLaLista(mision);
        GameObject.FindGameObjectWithTag("UI").transform.Find("ListaMisiones").gameObject.GetComponent<ListaMisionesCtrl>().ActualizarListaDeMisiones();
        
        if(mision.condicion != null) {
            Inventario.instance.QuitarElItemPorMision(mision.condicion);
        }
        //BuscarYHacerDisponibleMisionEnLaLista(mision.proxMision);
    }

    public void Entregar(Mision mision){
        BuscarYEntregarMisionEnLaLista(mision);
        GameObject.FindGameObjectWithTag("UI").transform.Find("ListaMisiones").gameObject.GetComponent<ListaMisionesCtrl>().ActualizarListaDeMisiones();
        
        int oroAAgregar = mision.recompensaOro;
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AgregarOro(oroAAgregar);
        Item recompensaItem = mision.recompensa;
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().AdquirirItem(recompensaItem);
        BuscarYHacerDisponibleMisionEnLaLista(mision.proxMision);
    }
    

    private void BuscarYEntregarMisionEnLaLista(Mision mision)
    {
        misiones2.Find(m=> m.nombreDeMision == mision.nombreDeMision).estadoDeMision = EstadoDeMision.Entregada;
    }
}