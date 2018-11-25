using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum EstadoDelBaul{Abierto, Cerrado};
public class BaulCrtl : MonoBehaviour {


	private Animator anim;
	private Animator mantenerAbierto;
	private Animator cerrarBaul;

	public GameObject baulUI;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		mantenerAbierto = GetComponent<Animator>();
		cerrarBaul = GetComponent<Animator>();
		GameObject.FindGameObjectWithTag("ParentBaulUI").SetActive(false);
		//baulUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
            AbrirBaul();
			mantenerAbierto.SetBool("mantenerbaulAbierto", true);
			
		}
}
    
void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
            AbrirBaul();
			mantenerAbierto.SetBool("mantenerbaulAbierto", true);
			
		}
		
}

void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player") {
             cerrarBaul.SetBool("cerrarBaul", true);
			 mantenerAbierto.SetBool("mantenerbaulAbierto", false);
			 anim.SetBool("apretaronParaAbrir", false);
			 baulUI.SetActive(false);
		}
}

	void AbrirBaul() {
		anim.SetBool("apretaronParaAbrir", true);
		cerrarBaul.SetBool("cerrarBaul", false);

		GameObject.FindGameObjectWithTag("baulUI").transform.Find("Canvas").gameObject.transform.Find("RawImage").gameObject.SetActive(true);
		//baulUI.SetActive(true);
	}

	public void AgregarItemAlBaul(Item item){
		if(anim.GetBool("mantenerbaulAbierto")){
			if(item != null){
			Inventario.instance.AgregarItemDelBaul(item);
			ActualizarSlotsBaul(item);
			
			}
		}
	}

	public void ActualizarSlotsBaul(Item item){
		List<BaulSlotCtrl> hijos = new List<BaulSlotCtrl>();

		GameObject parentBaulUI = GameObject.FindGameObjectWithTag("ParentBaulUI");

		parentBaulUI.GetComponentsInChildren(true,hijos);

        BaulSlotCtrl slotBaulVacio = BuscarSlotVacio(hijos);
        slotBaulVacio.AdquirirItem(item);
	}

	public BaulSlotCtrl BuscarSlotVacio(List<BaulSlotCtrl> hijos ){
		foreach(BaulSlotCtrl s in hijos){
           if(s.EstaVacio()){
               return s;
           }
        }
        throw new BaulLlenoException();
	}
}


