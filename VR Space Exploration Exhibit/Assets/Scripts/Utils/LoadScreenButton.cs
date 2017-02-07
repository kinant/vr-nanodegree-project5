using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenButton : MonoBehaviour {
	[SerializeField]
	private VRInteractiveItem m_VRInteractiveItem;

	public int num_scene_load;

	void OnEnable(){
		m_VRInteractiveItem.OnTrigger += LoadScreen;
	}

	void OnDisable(){
		m_VRInteractiveItem.OnTrigger -= LoadScreen;
	}


	private void LoadScreen(){
		if (num_scene_load < 0 || num_scene_load >= SceneManager.sceneCountInBuildSettings) {
			return;
		}
		LoadingScreenManager.LoadScene (num_scene_load);
	}
}