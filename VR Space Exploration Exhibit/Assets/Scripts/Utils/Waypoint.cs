using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	[SerializeField]
	private VRInteractiveItem m_VRInteractiveItem;

	[SerializeField]
	private string waypointName;

	private WaypointNetworkNavigation network;

	[SerializeField]
	private GameObject[] neighbors;

	void OnEnable(){
		m_VRInteractiveItem.OnEnter += HandleEnter;
		m_VRInteractiveItem.OnExit += HandleExit;
		m_VRInteractiveItem.OnTrigger += HandleTrigger;
	}

	void OnDisable(){
		m_VRInteractiveItem.OnEnter -= HandleEnter;
		m_VRInteractiveItem.OnExit -= HandleExit;
		m_VRInteractiveItem.OnTrigger -= HandleTrigger;
	}

	void Start(){
		network = GetComponentInParent<WaypointNetworkNavigation>();
	}

	private void HandleEnter(){
		// Debug.Log ("Enter waypoint: " + waypointName);
	}

	private void HandleExit(){
		// Debug.Log ("Exit waypoint: " + waypointName);
	}

	private void HandleTrigger(){
		Debug.Log ("Trigger waypoint: " + waypointName);
		network.WaypointSelected(this.gameObject);
	}

	public void EnableNeighbors(){
		if (!(neighbors.Length > 0))
			return;

		foreach (GameObject n in neighbors) {
			if (n.gameObject.GetComponentInParent<ParticleSystem> () != null) {
				n.gameObject.GetComponentInParent<ParticleSystem> ().Play ();
			}
            n.gameObject.SetActive (true);
        }
    }

	public void DisableNeighbors(){
		if (!(neighbors.Length > 0))
			return;

		foreach (GameObject n in neighbors) {
			if (n.gameObject.GetComponentInParent<ParticleSystem> () != null) {
				n.gameObject.GetComponentInParent<ParticleSystem> ().Stop ();
			}
            n.gameObject.SetActive (false);
		}
	}
}