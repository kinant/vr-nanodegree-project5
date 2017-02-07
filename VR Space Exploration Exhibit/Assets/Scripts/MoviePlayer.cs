using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviePlayer : MonoBehaviour {

    [SerializeField]
    private VRInteractiveItem m_VRInteractiveItem; // The VRInteractiveItem that needs to be looked at for the textures to play.

    [SerializeField]
    private MediaPlayerCtrl m_player;

    private bool isOver = false;

    private void OnEnable()
    {
        m_VRInteractiveItem.OnEnter += HandleOver;
        m_VRInteractiveItem.OnExit += HandleOut;
        m_player.OnReady += HandleOnReady;
    }

    private void OnDisable()
    {
        m_VRInteractiveItem.OnEnter -= HandleOver;
        m_VRInteractiveItem.OnExit -= HandleOut;
    }

    private void HandleOver() {
        isOver = true;
        m_player.Play();
    }

    private void HandleOut() {
        isOver = false;
        m_player.Pause();
    }

    private void HandleOnReady() {
        if (isOver)
            m_player.Play();
    }



}
