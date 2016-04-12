using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public AudioSource base_1;
    public AudioSource base_2;
    public AudioClip[] audios;
    float initVolume;
    int audioIndex = 0;
    public AudioSource menu_music;
    public AudioMixer audioMixer;
    private CreateItems createItems;

    bool swapping = false;

    private int version;

    public int Version
    {
        get
        {
            return version;
        }

        set
        {
            version = value;
            SwapSong();
        }
    }

    void Awake()
    {
        initVolume = base_1.volume;
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
            audioMixer.FindSnapshot("Base_1").TransitionTo(1f);
            createItems = GameObject.FindObjectOfType<CreateItems>();
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
        base_2.Stop();
    }

    void Update()
    {
        if (createItems!=null)
        {
            base_1.pitch = Mathf.Clamp(createItems.level * 0.005f + 1, 1, 1.3f);
            base_2.pitch = base_1.pitch;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Version = createItems.version;
            }
        }
    }

    public void SwapSong()
    {
        if (!swapping && base_1.isPlaying && base_1.time >= base_1.clip.length - 1 * base_1.pitch)
        {
            StartCoroutine(SwapSongCoroutine());
        }
    }

    IEnumerator SwapSongCoroutine()
    {
        audioIndex++;
        audioIndex %= audios.Length;
        base_2.Stop();
        base_2.clip = audios[audioIndex];
        base_2.Play();
        swapping = true;
        float progress=0;
        while (progress<1)
        {
            base_1.volume = Mathf.Lerp(initVolume, 0,progress);
            base_2.volume = Mathf.Lerp(0, initVolume, progress);
            progress += Time.deltaTime/(1*base_1.pitch);
            yield return null;
        }
        AudioSource temp = base_1;
        base_1 = base_2;
        base_2 = temp;
        swapping = false;
    }

    public void pauseMusic()
    {
        base_1.Pause();
        if (swapping)
            base_2.Pause();
    }

    public void resumeMusic()
    {
        base_1.Play();
        if (swapping)
            base_2.Play();
    }
}
