using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour {

	[SerializeField]
	private VRInteractiveItem m_VRInteractiveItem;

	void OnEnable(){
		m_VRInteractiveItem.OnTrigger += MenuButtonClicked;
	}

	void OnDisabled(){
		m_VRInteractiveItem.OnTrigger -= MenuButtonClicked;
	}
		
	void MenuButtonClicked(){
		SceneManager.LoadScene ("MainMenu");
	}

}
