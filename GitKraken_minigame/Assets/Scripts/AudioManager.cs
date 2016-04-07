using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioSource base_1;
    public AudioSource base_2;
    public AudioSource base_3;
    public AudioMixer audioMixer;

    void Awake()
    {
    }
	// Use this for initialization
	void Start () {
        base_1.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a"))
            swapSong(1);
        if (Input.GetKeyDown("b"))
            swapSong(2);
        if (Input.GetKeyDown("c"))
            swapSong(3);
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
            case 3:
                base_3.Play();
                base_3.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Music_1")[0];
                audioMixer.FindSnapshot("Base_1").TransitionTo(1f);
                break;

        }
    }
}
