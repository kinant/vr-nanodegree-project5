﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_interactiveItem;
	public GameObject nextCanvas;

	void OnEnable(){
		m_interactiveItem.OnTrigger += ButtonClicked;
	}

	void OnDisable(){
		m_interactiveItem.OnTrigger -= ButtonClicked;
	}

	private void ButtonClicked(){

		if (nextCanvas != null)
			nextCanvas.SetActive (true);

		gameObject.SetActive (false);
	}
}
