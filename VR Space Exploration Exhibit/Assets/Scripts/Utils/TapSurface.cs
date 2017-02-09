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
	private RaycastHit hit;

	void OnEnable(){
		m_VRInteractiveItem.OnTrigger += OnScreenTap;
	}

	void OnDisable(){
		m_VRInteractiveItem.OnTrigger -= OnScreenTap;
	}


	public void OnPointerEnter(){
		
	}

	public void OnScreenTap(){
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 100, surfaceLayer)) {
			Debug.Log ("raycast hit!");
			Debug.Log ("Target hit: " + hit.collider.tag);
			Debug.Log ("hit position: " + hit.point);
			roverNavMeshAgent.destination = hit.point;
            roverNavMeshAgent.gameObject.GetComponent<GvrAudioSource>().Play();
		}
	}
}
