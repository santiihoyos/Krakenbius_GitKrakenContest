using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using UnityEngine.Audio;

public class LoadApp : MonoBehaviour {

    public AudioMixer audioMixer;
    string AndroidPublisherKey= "baf254c1-b248-44bc-b098-0499d3b7891f";
    string iOSPublisherKey;

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


        AdBuddizBinding.SetLogLevel(AdBuddizBinding.ABLogLevel.Info);         // log level
        AdBuddizBinding.SetTestModeActive();                                  // to delete before submitting to store
        AdBuddizBinding.SetAndroidPublisherKey(AndroidPublisherKey); // replace with your Android app publisher key
        //AdBuddizBinding.SetIOSPublisherKey(iOSPublisherKey);         // replace with your iOS app publisher key
        AdBuddizBinding.CacheAds();
    }
}
