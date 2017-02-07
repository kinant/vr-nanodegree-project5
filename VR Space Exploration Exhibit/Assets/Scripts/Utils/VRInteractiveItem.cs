using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VRInteractiveItem : MonoBehaviour, IGvrGazeResponder {

	public event Action OnEnter;
	public event Action OnExit;
	public event Action OnTrigger;

	protected bool m_IsOver;

	public bool IsOver {
		get {
			return m_IsOver;
		}
	}

	// Implement IGvrGazeResponder
	public void OnGazeEnter(){

		m_IsOver = true;

		if (OnEnter != null)
			OnEnter ();
	}

	public void OnGazeExit(){

		m_IsOver = false;

		if (OnExit != null)
			OnExit ();
	}

	public void OnGazeTrigger(){
		if (OnTrigger != null)
			OnTrigger ();
	}
}
