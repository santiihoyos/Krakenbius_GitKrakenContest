using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public AudioSource base_1;
    public AudioSource base_2;
    public AudioSource menu_music;
    public AudioMixer audioMixer;

    void Awake()
    {
    }
	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {
            menu_music.Play();
            audioMixer.FindSnapshot("Menu").TransitionTo(1);
        }
        else if (SceneManager.GetActiveScene().name.Equals("GameScene"))
        {
            base_1.Play();
            audioMixer.FindSnapshot("Base_1").TransitionTo(0.2f);
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void swapSong(int level)
    {
        switch (level)
        {
            case 1:
                base_1.Play();
                audioMixer.FindSnapshot("Base_1").TransitionTo(1f);
                break;
            case 2:
                base_2.Play();
                audioMixer.FindSnapshot("Base_2").TransitionTo(1f);
                break;
            case 0:
                menu_music.Play();
                audioMixer.FindSnapshot("Menu").TransitionTo(1f);
                break;

        }
    }
}
