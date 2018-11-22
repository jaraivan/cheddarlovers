using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class VendedorCtrl : MonoBehaviour {

	// Use this for initialization
	private GameObject mercadoUI;
	public GameObject prefabItemEnUI;
	public Item pollo, pocion;

	void Awake(){

		mercadoUI = GameObject.FindGameObjectWithTag("UI").transform.Find("Mercado").gameObject;
		
	}
	void Start () {
		AgregarItemsAlMercado();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy(){
	List<ItemBotonYDescCtrl> hijos = new List<ItemBotonYDescCtrl>();
	GameObject verticalLayoutListaItems = GameObject.FindGameObjectWithTag("UI").gameObject.transform.Find("Mercado").gameObject.transform.Find("Canvas").gameObject.transform.Find("RawImage").gameObject.transform.Find("VerticalLayoutListaItems").gameObject;
	verticalLayoutListaItems.GetComponentsInChildren(true,hijos);

	foreach (var item in hijos)
	{
		Destroy(item.gameObject);	
	}
	}

	void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.Space))){
			this.mercadoUI.SetActive(true);
			//mercadoUI.transform.position = Camera.main.GetComponent<Transform>().position;
		}
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.Space))){
			this.mercadoUI.SetActive(true);
			//mercadoUI.transform.position = Camera.main.GetComponent<Transform>().position;
		}
    }

	void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
			this.mercadoUI.SetActive(false);
		}
    }

	private void AgregarItemsAlMercado(){
		AgregarItem(pollo);
		AgregarItem(pocion);
	}

	private void AgregarItem(Item item){
		
		GameObject verticalLayoutListaItems = GameObject.FindGameObjectWithTag("UI").gameObject.transform.Find("Mercado").gameObject.transform.Find("Canvas").gameObject.transform.Find("RawImage").gameObject.transform.Find("VerticalLayoutListaItems").gameObject;
		GameObject itemEnUI = Object.Instantiate(prefabItemEnUI,verticalLayoutListaItems.transform.position,Quaternion.identity);
		itemEnUI.transform.SetParent(verticalLayoutListaItems.transform,false);
		itemEnUI.GetComponent<ItemBotonYDescCtrl>().SetealeTodo(item);

	}


}
