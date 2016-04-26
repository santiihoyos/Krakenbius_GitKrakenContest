using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDPanelController : MonoBehaviour {

	bool isPaused = false;
	GameObject pausePanel;
    GameObject gameOverPanel;
    GameObject captionPanel;
    GameObject pauseButton;

    // Use this for initialization
    void Start () {
		pausePanel = GameObject.Find ("PanelPause");
		pausePanel.SetActive(false);
        gameOverPanel = GameObject.Find("PanelGameOver");
        gameOverPanel.SetActive(false);
        captionPanel = GameObject.Find("Caption_Panel");
        captionPanel.SetActive(false);
        pauseButton = GameObject.Find("Pause_Button");
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
            pauseButton.SetActive(true);
            captionPanel.SetActive(false);
            GameObject.FindObjectOfType<AudioManager>().resumeMusic();
		} else {
			Time.timeScale = 0;
			isPaused = true;
			pausePanel.SetActive(true);
            pauseButton.SetActive(false);
            captionPanel.SetActive(true);
            GameObject.FindObjectOfType<AudioManager>().pauseMusic();
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
        if (AdBuddizBinding.IsReadyToShowAd())
        {
            AdBuddizBinding.ShowAd(); // showAd will always display an ad
        }
        else {
            // use another ad network
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    //void OnEnable()
    //{ // register as a listener
    //    AdBuddizManager.didCacheAd += DidCacheAd;
    //    AdBuddizManager.didShowAd += DidShowAd;
    //    AdBuddizManager.didFailToShowAd += DidFailToShowAd;
    //    AdBuddizManager.didClick += DidClick;
    //    AdBuddizManager.didHideAd += DidHideAd;
    //}
    //
    //void OnDisable()
    //{ // unregister as a listener
    //    AdBuddizManager.didCacheAd -= DidCacheAd;
    //    AdBuddizManager.didShowAd -= DidShowAd;
    //    AdBuddizManager.didFailToShowAd -= DidFailToShowAd;
    //    AdBuddizManager.didClick -= DidClick;
    //    AdBuddizManager.didHideAd -= DidHideAd;
    //}
    //
    //void DidCacheAd() { } // an Ad was cached
    //void DidShowAd() { } // an Ad was displayed
    //void DidFailToShowAd(string adBuddizError) { } // no Ad was displayed 
    //void DidClick() { } // the Ad was clicked
    //void DidHideAd() { } // the Ad was hidden 
}
