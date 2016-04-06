using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using UnityEngine.Audio;

public class LoadApp : MonoBehaviour {

	public GameObject menuPanel;

    public AudioMixer audioMixer;

	void Awake () 
	{
	}

	// Use this for initialization
	void Start () 
	{
        InitApp();
        if (PlayerPrefs.GetInt("music") == 1)
            audioMixer.SetFloat("MusicVolume", 0f);
        else
            audioMixer.SetFloat("MusicVolume", -80f);

        if (PlayerPrefs.GetInt("effects") == 1)
            audioMixer.SetFloat("EffectsVolume", 0f);
        else
            audioMixer.SetFloat("EffectsVolume", -80f);
    }

	// SELECT OF PANEL LOAD
	private void InitApp () {
        GameObject menuPanelGO = Instantiate (menuPanel) as GameObject;
        menuPanelGO.transform.SetParent(this.transform, false);
	}
}
