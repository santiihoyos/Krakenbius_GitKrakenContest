using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDPanelController : MonoBehaviour {

	bool isPaused = false;
	GameObject pausePanel;

    // Use this for initialization
    void Start () {
		pausePanel = GameObject.Find ("PanelPause");
		pausePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Pause() {
		if (isPaused) {
			Time.timeScale = 1;
			isPaused = false;
			pausePanel.SetActive(false);
		} else {
			Time.timeScale = 0;
			isPaused = true;
			pausePanel.SetActive(true);
		}
	}

    public void Home()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
        Debug.Log("Go home");
    }
}
