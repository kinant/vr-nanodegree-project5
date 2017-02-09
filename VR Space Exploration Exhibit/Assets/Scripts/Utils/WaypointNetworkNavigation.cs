using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNetworkNavigation : MonoBehaviour {

	[SerializeField]
	private Player player;
	private GameObject currentWaypoint;
	private GameObject previousWaypoint;

	public GameObject[] waypoints;

	void Start(){

		// disable all the waypoints
		foreach (GameObject w in waypoints) {
			if (w.GetComponentInParent<ParticleSystem> () != null) {
				w.GetComponentInParent<ParticleSystem> ().Stop ();
			}
            w.SetActive (false);
		}
		// enable just the first waypoint
		waypoints[0].SetActive(true);
		if (waypoints [0].GetComponentInParent<ParticleSystem> () != null) {
			waypoints [0].GetComponentInParent<ParticleSystem> ().Play ();
		}
    }

	public void WaypointSelected(GameObject w){

		// assign the previous waypoint
		if (currentWaypoint != null) {
			previousWaypoint = currentWaypoint;
		}

		// assign the new current waypoint
		currentWaypoint = w;

		// enable current waypoint neighbors
		currentWaypoint.GetComponent<Waypoint>().EnableNeighbors();

		// disable previous waypoint neighbors
		if (previousWaypoint != null) {
			previousWaypoint.GetComponent<Waypoint> ().DisableNeighbors ();
		}

		// disable current waypoint
		w.SetActive(false);
        w.GetComponentInParent<ParticleSystem>().Stop();

        // move the player
        player.moveTo (currentWaypoint.transform.position);
        player.gameObject.GetComponent<GvrAudioSource>().Play();
	}
}