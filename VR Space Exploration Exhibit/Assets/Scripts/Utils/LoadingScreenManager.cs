// LoadingScreenManager
// --------------------------------
// built by Martin Nerurkar (http://www.martin.nerurkar.de)
// for Nowhere Prophet (http://www.noprophet.com)
//
// Licensed under GNU General Public License v3.0
// http://www.gnu.org/licenses/gpl-3.0.txt

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour {

	[Header("Loading Visuals")]
	// public Image loadingIcon;
	// public Image loadingDoneIcon;
	// public Text loadingText;
	// public Image progressBar;
	public Image fadeOverlay;

	[Header("Timing Settings")]
	public float waitOnLoadEnd = 0.25f;
	public float fadeDuration = 0.25f;

	[Header("Loading Settings")]
	public LoadSceneMode loadSceneMode = LoadSceneMode.Single;
	public ThreadPriority loadThreadPriority;

	[Header("Other")]
	// If loading additive, link to the cameras audio listener, to avoid multiple active audio listeners
	public AudioListener audioListener;

    public MediaPlayerCtrl m_mediaPlayerCtrl;

    private bool mediaOver;
    public static string mediaName;

    public GameObject temporarySign;

	AsyncOperation operation;
	Scene currentScene;

	public static int sceneToLoad = -1;
	// IMPORTANT! This is the build index of your loading scene. You need to change this to match your actual scene index
	static int loadingSceneIndex = 1;

	public static void LoadScene(int levelNum, string n) {				
		Application.backgroundLoadingPriority = ThreadPriority.High;
		sceneToLoad = levelNum;
        mediaName = n;
        SceneManager.LoadScene(loadingSceneIndex);
	}

    private void Awake()
    {
        //m_mediaPlayerCtrl.m_strFileName = "mars360.mp4";
    }

    private void OnEnable()
    {
        m_mediaPlayerCtrl.OnEnd += MediaPlayOver;
    }

    private void OnDisable()
    {
        m_mediaPlayerCtrl.OnEnd -= MediaPlayOver;
    }

    void MediaPlayOver()
    {
        mediaOver = true;
    }

    void Start() {
		if (sceneToLoad < 0)
			return;

        mediaOver = false;

        fadeOverlay.gameObject.SetActive(true); // Making sure it's on so that we can crossfade Alpha
		currentScene = SceneManager.GetActiveScene();

        Destroy(temporarySign, 3);

		StartCoroutine(LoadAsync(sceneToLoad));
	}

    private void Update()
    {
        if (GvrViewer.Instance.Triggered) {
            mediaOver = true;
        }
    }

    private IEnumerator LoadAsync(int levelNum) {
		ShowLoadingVisuals();
        m_mediaPlayerCtrl.Load(mediaName);

        yield return null; 

		FadeIn();
        StartOperation(levelNum);

		float lastProgress = 0f;

		// operation does not auto-activate scene, so it's stuck at 0.9
		while (DoneLoading() == false && mediaOver == false) {
			yield return null;

			if (Mathf.Approximately(operation.progress, lastProgress) == false) {
				// progressBar.fillAmount = operation.progress;
				lastProgress = operation.progress;
			}
		}

		if (loadSceneMode == LoadSceneMode.Additive)
			audioListener.enabled = false;

		ShowCompletionVisuals();

		yield return new WaitForSeconds(waitOnLoadEnd);

		FadeOut();

		yield return new WaitForSeconds(fadeDuration);

		if (loadSceneMode == LoadSceneMode.Additive)
			SceneManager.UnloadScene(currentScene.name);
		else
			operation.allowSceneActivation = true;
	}

	private void StartOperation(int levelNum) {
		Application.backgroundLoadingPriority = loadThreadPriority;
		operation = SceneManager.LoadSceneAsync(levelNum, loadSceneMode);


		if (loadSceneMode == LoadSceneMode.Single)
			operation.allowSceneActivation = false;
	}

	private bool DoneLoading() {
		return (mediaOver && loadSceneMode == LoadSceneMode.Additive && operation.isDone) || (mediaOver && loadSceneMode == LoadSceneMode.Single && operation.progress >= 0.9f);
        // return (loadSceneMode == LoadSceneMode.Additive && operation.isDone) || (loadSceneMode == LoadSceneMode.Single && operation.progress >= 0.9f);
    }

    void FadeIn() {
		fadeOverlay.CrossFadeAlpha(0, fadeDuration, true);
    }

	void FadeOut() {
		fadeOverlay.CrossFadeAlpha(1, fadeDuration, true);
	}

	void ShowLoadingVisuals() {
		// loadingIcon.gameObject.SetActive(true);
		// loadingDoneIcon.gameObject.SetActive(false);

		// progressBar.fillAmount = 0f;
		// loadingText.text = "LOADING...";
	}

	void ShowCompletionVisuals() {
		// loadingIcon.gameObject.SetActive(false);
		// loadingDoneIcon.gameObject.SetActive(true);

		// progressBar.fillAmount = 1f;
		// loadingText.text = "LOADING DONE";
	}
}
