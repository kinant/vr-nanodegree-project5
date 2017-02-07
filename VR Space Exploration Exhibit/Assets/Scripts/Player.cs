using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public void moveTo(Vector3 position){
		// move the player
		iTween.MoveTo (gameObject, position, 2);
	}
}