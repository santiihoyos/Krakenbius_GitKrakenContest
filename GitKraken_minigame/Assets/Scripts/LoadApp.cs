using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using UnityEngine.Audio;

public class LoadApp : MonoBehaviour {

    public AudioMixer audioMixer;
    string AndroidPublisherKey= "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAxOxZykNeqUMbgIZ+qSGKqHrTxn44cGm5xCshkgUdO6en6vbJLCl1a8K1K4WEzY8TPFdNDGMrWiQ2FY271ywVfd1+c8CSat2zdfqPPpJinqOrpsiwNa3HgcX+XjIPK+M15KjQyAStbr5mufMMg2bJ9m4EZ0uiVs1AGmdOZ/6vFxSJ5xH0N7y7aac7U79PjgvMxNhAZytux+CLXHJ+oakCBELY0WoyhUnGaCZlk9CIsB5AbqhtlJJqOJ5IfVGOT3Fz+Q217Uu6aJXQYHAqkbG1SbDWxTzV2MpmT51KaY61DhE1oVxhHok+gr9h0aca/4SPuCTPRF5Ewptuk2H104DsJQIDAQAB";
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
