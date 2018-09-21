using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorCtrl : MonoBehaviour {

	public float speed = 3f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(SeEstaPresionando(KeyCode.RightArrow)){
			MoverA(Vector2.right);
		}
		if(SeEstaPresionando(KeyCode.LeftArrow)){
			MoverA(Vector2.left);
		}
		if(SeEstaPresionando(KeyCode.DownArrow)){
			MoverA(Vector2.down);
		}
		if(SeEstaPresionando(KeyCode.UpArrow)){
			MoverA(Vector2.up);
		}

	}

	void MoverA(Vector2 direccion){
		transform.Translate(direccion * speed * Time.deltaTime);
	}
	bool SeEstaPresionando(KeyCode tecla){
		return Input.GetKey(tecla);
	}
}
