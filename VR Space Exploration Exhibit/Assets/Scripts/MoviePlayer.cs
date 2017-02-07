using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviePlayer : MonoBehaviour {

    [SerializeField]
    private VRInteractiveItem m_VRInteractiveItem; // The VRInteractiveItem that needs to be looked at for the textures to play.

    [SerializeField]
    private MediaPlayerCtrl m_player;

    private void OnEnable()
    {
        m_VRInteractiveItem.OnEnter += HandleOver;
        m_VRInteractiveItem.OnExit += HandleOut;
    }


    private void OnDisable()
    {
        m_VRInteractiveItem.OnEnter -= HandleOver;
        m_VRInteractiveItem.OnExit -= HandleOut;
    }

    private void HandleOver() {
        m_player.Play();
    }

    private void HandleOut() {
        m_player.Stop();
    }


}
