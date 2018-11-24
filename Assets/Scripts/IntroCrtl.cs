using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroCrtl : MonoBehaviour {

	private VideoPlayer intro;


	// Use this for initialization
	void Awake () {
		intro = GetComponent<VideoPlayer>();
	}

	void Start() {
		intro.loopPointReached += TerminarIntro;
	}
	
 void TerminarIntro(VideoPlayer vp) {
	SceneManager.LoadScene(2);
}
	
}
