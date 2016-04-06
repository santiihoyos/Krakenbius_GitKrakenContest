using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour {

    [Header("Audio Controll Buttons")]
    public Toggle musicButton;
    public Toggle effectsButton;

    [Header("Music Mixer")]
    public AudioMixer audioMixer;

    private int musicState;
    private int effectsState;

    public int MusicState
    {
        get
        {
            return musicState;
        }

        set
        {
            musicState = value;
        }
    }

    public int EffectsState
    {
        get
        {
            return effectsState;
        }

        set
        {
            effectsState = value;
        }
    }

    // Use this for initialization
    void Start () {
        #region CheckAudioPrefs
        if (PlayerPrefs.HasKey("music"))
        {
            MusicState = PlayerPrefs.GetInt("music");
            if (MusicState == 1)
                musicButton.isOn = true;
            else
                musicButton.isOn = false;
        }
        else
        {
            if (musicButton.isOn)
                MusicState = 1;
            else
                MusicState = 0;

            PlayerPrefs.SetInt("music", MusicState);
        }

        if (PlayerPrefs.HasKey("effects"))
        {
            EffectsState = PlayerPrefs.GetInt("effects");
            if (EffectsState == 1)
                effectsButton.isOn = true;
            else
                effectsButton.isOn = false;
        }
        else
        {
            if (effectsButton.isOn)
                EffectsState = 1;
            else
                EffectsState = 0;

            PlayerPrefs.SetInt("effects", EffectsState);
        }
        #endregion
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update () {
	    
	}

    public void toggleMusic()
    {
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        if (musicButton.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            audioMixer.SetFloat("MusicVolume", 0f);
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            audioMixer.SetFloat("MusicVolume", -80f);
        }
    }

    public void toggleEffects()
    {
        ((AudioSource)GameObject.Find("Mouse_Effect").GetComponent<AudioSource>()).Play();
        if (effectsButton.isOn)
        {
            PlayerPrefs.SetInt("effects", 1);
            audioMixer.SetFloat("EffectsVolume", 0f);
        }
        else
        {
            PlayerPrefs.SetInt("effects", 0);
            audioMixer.SetFloat("EffectsVolume", -80f);
        }
    }
}
