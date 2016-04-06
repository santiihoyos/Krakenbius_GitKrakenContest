using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class LoadApp : MonoBehaviour {

	public GameObject menuPanel;

	private AudioSource soundMusicMenu;
	private AudioSource soundButtonClick;
	private AudioSource soundTapClick;

	void Awake () 
	{
	}

	// Use this for initialization
	void Start () 
	{
        InitApp();
    }

	// SELECT OF PANEL LOAD
	private void InitApp () {
        GameObject menuPanelGO = Instantiate (menuPanel) as GameObject;
        menuPanelGO.transform.SetParent(this.transform, false);
	}
}
