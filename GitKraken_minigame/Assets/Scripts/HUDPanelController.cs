using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUDPanelController : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goHome()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("Go home");
    }
}
