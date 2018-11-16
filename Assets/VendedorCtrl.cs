using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendedorCtrl : MonoBehaviour {

	// Use this for initialization
	private GameObject mercadoUI;
	public GameObject prefabItemEnUI;

	void Awake(){

		mercadoUI = GameObject.FindGameObjectWithTag("UI").transform.Find("Mercado").gameObject;
		
	}
	void Start () {
		AgregarItemsAlMercado();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.Space))){
			mercadoUI.SetActive(true);
			//mercadoUI.transform.position = Camera.main.GetComponent<Transform>().position;
		}
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.Space))){
			mercadoUI.SetActive(true);
			//mercadoUI.transform.position = Camera.main.GetComponent<Transform>().position;
		}
    }

	void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
			mercadoUI.SetActive(false);
		}
    }

	private void AgregarItemsAlMercado(){
		AgregarItem("pollo");
		AgregarItem("pocion");
	}

	private void AgregarItem(string nombreItem){
		
		GameObject verticalLayoutListaItems = GameObject.FindGameObjectWithTag("UI").gameObject.transform.Find("Mercado").gameObject.transform.Find("Canvas").gameObject.transform.Find("RawImage").gameObject.transform.Find("VerticalLayoutListaItems").gameObject;
		GameObject itemEnUI = Object.Instantiate(prefabItemEnUI,verticalLayoutListaItems.transform.position,Quaternion.identity);

		itemEnUI.transform.SetParent(verticalLayoutListaItems.transform,false);
		itemEnUI.GetComponent<ItemBotonYDescCtrl>().SetImagenPara(nombreItem);
		itemEnUI.GetComponent<ItemBotonYDescCtrl>().SetDescripcionPara(nombreItem);
		itemEnUI.GetComponent<ItemBotonYDescCtrl>().SetPrecioPara(nombreItem);
	}
}
