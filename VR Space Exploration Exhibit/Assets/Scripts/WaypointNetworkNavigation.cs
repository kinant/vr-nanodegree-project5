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
			w.SetActive (false);
		}
		// enable just the first waypoint
		waypoints[0].SetActive(true);
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

		// move the player
		player.moveTo (currentWaypoint.transform.position);
	}
}