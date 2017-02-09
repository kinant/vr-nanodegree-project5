using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public void moveTo(Vector3 position){
        // move the player
        //float x = position.x;
        //float y = position.y;
        //float z = position.z;

		iTween.MoveTo (gameObject, position + new Vector3(0f,1.5f,0f), 2);
	}
}