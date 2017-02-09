using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWaypointSound : MonoBehaviour {

    public GvrAudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDED WITH TRIGGER!!!");
        audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        audioSource.Stop();
    }


}
