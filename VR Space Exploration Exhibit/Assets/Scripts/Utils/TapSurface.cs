using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TapSurface : MonoBehaviour {

	[SerializeField]
	private VRInteractiveItem m_VRInteractiveItem;

	[SerializeField]
	private NavMeshAgent roverNavMeshAgent;

	public LayerMask surfaceLayer;
	public GameObject reticlePointer;

	private RaycastHit hit;

	void OnEnable(){
		m_VRInteractiveItem.OnEnter += OnPointerEnter;
		m_VRInteractiveItem.OnExit += OnPointerExit;
		m_VRInteractiveItem.OnTrigger += OnScreenTap;
	}

	void OnDisable(){
		m_VRInteractiveItem.OnEnter -= OnPointerEnter;
		m_VRInteractiveItem.OnExit -= OnPointerExit;
		m_VRInteractiveItem.OnTrigger -= OnScreenTap;
	}
		
	public void OnPointerEnter(){
		reticlePointer.GetComponent<Renderer> ().material.color = Color.green;
	}

	public void OnPointerExit(){
		reticlePointer.GetComponent<Renderer> ().material.color = Color.white;
	}
		
	public void OnScreenTap(){
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 100, surfaceLayer)) {
			// Debug.Log ("raycast hit!");
			// Debug.Log ("Target hit: " + hit.collider.tag);
			// Debug.Log ("hit position: " + hit.point);
			roverNavMeshAgent.destination = hit.point;
            roverNavMeshAgent.gameObject.GetComponent<GvrAudioSource>().Play();
		}
	}
}
