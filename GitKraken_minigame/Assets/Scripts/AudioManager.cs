using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public AudioSource base_1;
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
            audioMixer.FindSnapshot("Menu").TransitionTo(1f);
        }
        else if (SceneManager.GetActiveScene().name.Equals("GameScene"))
        {
            base_1.Play();
            audioMixer.FindSnapshot("Base_1").TransitionTo(0.2f);
        }
	}
	
	// Update is called once per frame
	public void PitchBase() {
        StartCoroutine(PitchBaseCoroutine());
    }

    IEnumerator PitchBaseCoroutine()
    {
        audioMixer.FindSnapshot("Base_1_PitchDown").TransitionTo(2f);
        yield return new WaitForSeconds(2);
        base_1.Stop();
    }
}
