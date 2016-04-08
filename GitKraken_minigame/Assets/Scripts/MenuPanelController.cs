using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPanelController : MonoBehaviour {

	// References Panel
    [Header("UI Panels")]
	public GameObject mainPanel;
	public GameObject settingsPanel;
	public GameObject creditsPanel;
    public GameObject gamePanel;
    public GameObject rankingPanel;

    [Header("AudioManager")]
    public AudioManager audioManager;

    //*********************************************** BUTTON RETURN MAIN MENU *****************************************************
    public void HomeButton() 
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        GameObject mainPanelGO = Instantiate (mainPanel) as GameObject;
		Destroy (GameObject.Find ("SettingsPanel(Clone)"));
		Destroy (GameObject.Find ("CreditsPanel(Clone)"));
	}

	//*********************************************** BUTTONS MAIN MENU *****************************************************
	public void SettingsButton ()
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        GameObject settingsPanelGO = Instantiate (settingsPanel) as GameObject;
        Destroy (GameObject.Find ("MainPanel(Clone)"));
	}

	public void CreditsButton () 
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        GameObject creditsPanelGO = Instantiate (creditsPanel) as GameObject;
        Destroy (GameObject.Find ("MainPanel(Clone)"));
	}

    public void PlayButton()
    {
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        Destroy(GameObject.Find("MainPanel(Clone)"));
        SceneManager.LoadScene("GameScene");
    }

    public void RankingButton()
    {
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        GameObject creditsPanelGO = Instantiate(rankingPanel) as GameObject;
        Destroy(GameObject.Find("MainPanel(Clone)"));
    }
}
