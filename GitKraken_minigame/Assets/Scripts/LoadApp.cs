using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class LoadApp : MonoBehaviour {

	public GameObject menuPanel;

	private AudioSource soundMusicMenu;
	private AudioSource soundButtonClick;
	private AudioSource soundAmmoClick;
	private AudioSource soundTapClick;

	void Awake () 
	{
		// Loading sound components
		soundMusicMenu = GameObject.Find ("MusicMenu").GetComponent<AudioSource>();
		soundButtonClick = GameObject.Find ("SoundButton").GetComponent<AudioSource>();
		soundAmmoClick = GameObject.Find ("SoundAmmo").GetComponent<AudioSource>();
		soundTapClick = GameObject.Find ("SoundTap").GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () 
	{
		// Load preferences
		MusicControl(PlayerPrefs.GetInt("music"));
		SoundControl(PlayerPrefs.GetInt("sound"));
        InitApp();
    }

	// SELECT OF PANEL LOAD
	private void InitApp () {
        GameObject menuPanelGO = Instantiate (menuPanel) as GameObject;
        menuPanelGO.transform.SetParent(this.transform, false);
	}

	private void MusicControl (int value) {
		if (value == 1) {
			soundMusicMenu.mute = false;
		} else {
			soundMusicMenu.mute = true;
		}
	}

	private void SoundControl (int value) {
		if (value == 1) {
			soundButtonClick.mute = false;
			soundAmmoClick.mute = false;
			soundTapClick.mute = false;
		} else {
			soundButtonClick.mute = true;
			soundAmmoClick.mute = true;
			soundTapClick.mute = true;
		}
	}
}
