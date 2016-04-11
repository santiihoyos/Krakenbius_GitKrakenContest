using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPanelController : MonoBehaviour {

	// References Panel
    [Header("UI Panels")]
	public GameObject mainPanel;
	public GameObject settingsPanel;
	public GameObject creditsPanel;

    public GameObject rankingPanel;
    public GameObject titlePanel;

    [Header("AudioManager")]
    public AudioManager audioManager;

    //*********************************************** BUTTON RETURN MAIN MENU *****************************************************
    public void HomeButton() 
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        mainPanel.SetActive(true);
		settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

	//*********************************************** BUTTONS MAIN MENU *****************************************************
	public void SettingsButton ()
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

	public void CreditsButton () 
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void PlayButton()
    {
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        //Destroy(GameObject.Find("MainPanel(Clone)"));
        SceneManager.LoadScene("GameScene");
    }

    public void RankingButton()
    {
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        rankingPanel.SetActive(!rankingPanel.activeInHierarchy);
        titlePanel.SetActive(!titlePanel.activeInHierarchy);
    }
}
