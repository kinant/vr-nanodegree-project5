using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour {

	public Image fadeOverlay;
	public float fadeSpeed = 1.5f;
	public bool sceneStarting = true;

	void Awake(){
		//fadeOverlay.enabled = true;
	}

	void Update(){
		if (sceneStarting) {
			StartScene ();
		}
	}

	void FadeToClear(){
		fadeOverlay.color = Color.Lerp (fadeOverlay.color, Color.clear, fadeSpeed * Time.deltaTime);
	}

	void StartScene(){
		FadeToClear ();

		if (fadeOverlay.color.a <= 0.05f) {

			fadeOverlay.color = Color.clear;
			fadeOverlay.enabled = false;

			sceneStarting = false;
		}
	}
}
