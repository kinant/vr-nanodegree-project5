using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public Transform endpos;
	public GameObject player;

	// Use this for initialization
	void Start () {
		iTween.MoveTo (player, endpos.transform.position, 20);	
	}
}
