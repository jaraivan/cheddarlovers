using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MuelleCtrl : MonoBehaviour {


	private VideoPlayer videoPlayer;

	void Start () {
		videoPlayer = GetComponent<VideoPlayer>();
		videoPlayer.loopPointReached += TerminarVideo;
	}

    private void TerminarVideo(VideoPlayer source)
    {
        videoPlayer.Stop();
    }

    void OnTriggerStay2D(Collider2D col){

		if(col.gameObject.tag == "Player"){
			GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().SetMuelleActual(gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col){

		if(col.gameObject.tag == "Player"){
			GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCtrl>().SetMuelleActual(null);
		}
	}


	public void CruzarEnBote(){
		ReproducirVideo();

		Transform transformLucas = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		Transform targetTransform = transform.Find("target").gameObject.GetComponent<Transform>();
		
		transformLucas.position = targetTransform.position;
	}

    private void ReproducirVideo()
    {
        videoPlayer.Play();
    }
	
}
