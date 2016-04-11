using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using UnityEngine.Audio;

public class LoadApp : MonoBehaviour {

    public AudioMixer audioMixer;

	// Use this for initialization
	void Start () 
	{
        if (!PlayerPrefs.HasKey("music")){
            PlayerPrefs.SetInt("music", 1);
        }
        if (!PlayerPrefs.HasKey("effects"))
        {
            PlayerPrefs.SetInt("effects", 1);
        }

        if (PlayerPrefs.GetInt("music") == 1)
            audioMixer.SetFloat("MusicVolume", 0f);
        else
            audioMixer.SetFloat("MusicVolume", -80f);

        if (PlayerPrefs.GetInt("effects") == 1)
            audioMixer.SetFloat("EffectsVolume", 0f);
        else
            audioMixer.SetFloat("EffectsVolume", -80f);
    }
}
