using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

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
        menu_music.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a"))
            swapSong(1);
        if (Input.GetKeyDown("b"))
            swapSong(2);
        if (Input.GetKeyDown("c"))
            swapSong(0);
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
