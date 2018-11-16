using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBotonYDescCtrl : MonoBehaviour {

	// Use this for initialization
	private Image image;

	public Sprite pocionSprite;
	public Sprite polloSprite;
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetImagenPara(string nombreDeItem){
		image = transform.Find("BotonItem").gameObject.transform.Find("ImagenDelItem").gameObject.GetComponent<Image>();
		switch (nombreDeItem){
			case "pocion":
			image.sprite = pocionSprite;
			break;

			case "pollo":
			image.sprite = polloSprite;
			break;

		}

	}


}
