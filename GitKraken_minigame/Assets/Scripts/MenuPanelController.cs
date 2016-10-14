using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class MenuPanelController : MonoBehaviour {

	// References Panel
    [Header("UI Panels")]
	public GameObject mainPanel;
	public GameObject settingsPanel;
	public GameObject creditsPanel;
    public GameObject manPanel;

    public GameObject rankingPanel;
    public GameObject titlePanel;

    public GameObject exitButton;
    public GameObject twitterButton;
    public GameObject confirmExitPanel;
	public GameObject deleteAdsPanel;

    [Header("AudioManager")]
    public AudioManager audioManager;

	[Header("External Methods")]
	public Purchaser purchaser;

#if !UNITY_ANDROID
    void Start()
    {
        exitButton.SetActive(false);
        twitterButton.SetActive(false);
    }
#endif
    //*********************************************** BUTTON RETURN MAIN MENU *****************************************************
    public void HomeButton() 
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        mainPanel.SetActive(true);
		settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        manPanel.SetActive(false);
    }

	//*********************************************** BUTTONS MAIN MENU *****************************************************
	public void SettingsButton ()
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        manPanel.SetActive(false);
    }

	public void CreditsButton () 
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
        manPanel.SetActive(false);
    }
    public void ManButton()
    {
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        manPanel.SetActive(true);
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

    public void ExitButton()
    {
        confirmExitPanel.SetActive(true);
    }

    public void ConfirmExit()
    {
        Application.Quit();
    }

    public void CancelExit()
    {
        confirmExitPanel.SetActive(false);
    }

    public void GoToTwitter()
    {
        Application.OpenURL("https://twitter.com/allinbyte/status/719536813896019968");
    }

	public void showDeleteAdsPanel()
	{
		deleteAdsPanel.SetActive (true);
	}

	public void hideDeleteAdsPanel()
	{
		deleteAdsPanel.SetActive (false);
	}

	public void DeleteAdsConfirmation()
	{
		//Add IAP Delete Ads
		purchaser.BuyNonConsumable();
		
		hideDeleteAdsPanel();
	}
}
