using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPanelController : MonoBehaviour {

	// References Panel
    [Header("UI Panels")]
	public GameObject mainPanel;
	public GameObject settingsPanel;
	public GameObject creditsPanel;

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

	//*********************************************** OTHER BUTTONS *****************************************************

	// IN SSETTINGSPANEL
	public void CreditsButton () 
	{
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        GameObject creditsPanelGO = Instantiate (creditsPanel) as GameObject;
        Destroy (GameObject.Find ("MainPanel(Clone)"));
	}
}
