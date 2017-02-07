using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VRInteractiveItem : MonoBehaviour, IGvrGazeResponder {

	public event Action OnEnter;
	public event Action OnExit;
	public event Action OnTrigger;

	// Implement IGvrGazeResponder
	public void OnGazeEnter(){
		if (OnEnter != null)
			OnEnter ();
	}

	public void OnGazeExit(){
		if (OnExit != null)
			OnExit ();
	}

	public void OnGazeTrigger(){
		if (OnTrigger != null)
			OnTrigger ();
	}
}
