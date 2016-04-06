using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPanelController : MonoBehaviour {

	// References Panel
    [Header("UI Panels")]
	public GameObject mainPanel;
	public GameObject settingsPanel;
	public GameObject creditsPanel;

    [Header("Audio Resources")]
    public AudioSource mouse_effect;

    //*********************************************** BUTTON RETURN MAIN MENU *****************************************************
    public void HomeButton() 
	{
        mouse_effect.Play();
		GameObject mainPanelGO = Instantiate (mainPanel) as GameObject;
		Destroy (GameObject.Find ("SettingsPanel(Clone)"));
		Destroy (GameObject.Find ("CreditsPanel(Clone)"));
	}

	//*********************************************** BUTTONS MAIN MENU *****************************************************
	public void SettingsButton ()
	{
        mouse_effect.Play();
        GameObject settingsPanelGO = Instantiate (settingsPanel) as GameObject;
        Destroy (GameObject.Find ("MainPanel(Clone)"));
	}

	//*********************************************** OTHER BUTTONS *****************************************************

	// IN SSETTINGSPANEL
	public void CreditsButton () 
	{
        mouse_effect.Play();
        GameObject creditsPanelGO = Instantiate (creditsPanel) as GameObject;
        Destroy (GameObject.Find ("MainPanel(Clone)"));
	}
}
