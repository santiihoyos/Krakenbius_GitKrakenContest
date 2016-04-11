using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDPanelController : MonoBehaviour {

	bool isPaused = false;
	GameObject pausePanel;
    GameObject gameOverPanel;

    // Use this for initialization
    void Start () {
		pausePanel = GameObject.Find ("PanelPause");
		pausePanel.SetActive(false);
        gameOverPanel = GameObject.Find("PanelGameOver");
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
	
	}

	public void Pause() {
        if (gameOverPanel.activeInHierarchy)
            return;
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

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
