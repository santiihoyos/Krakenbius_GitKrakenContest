using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	public Toggle musicButton;
	public Toggle soundButton;

	private AudioSource soundMusicMenu;
	private AudioSource soundButtonClick;
	private AudioSource soundAmmoClick;
	private AudioSource soundTapClick;

	private int on = 1;
	private int off = 0;

	void Awake () {
		soundMusicMenu = GameObject.Find ("MusicMenu").GetComponent<AudioSource>();
		soundButtonClick = GameObject.Find ("SoundButton").GetComponent<AudioSource>();
		soundTapClick = GameObject.Find ("SoundTap").GetComponent<AudioSource>();

		MusicControl(PlayerPrefs.GetInt("music"));
		SoundControl(PlayerPrefs.GetInt("sound"));
	}


	// **************************************************** SETTINGS CLICKS *************************************************************************
	public void ClickMusicButton () {
		if (GameObject.Find ("SoundButton") != null) {
			((AudioSource) GameObject.Find("SoundButton").GetComponent<AudioSource>()).Play();
		}

		if (musicButton.isOn) {
			print ("MUSIC ON");
			PlayerPrefs.SetInt ("music", on);
			MusicControl (on);
		} else {
			print ("MUSIC OFF");
			PlayerPrefs.SetInt ("music", off);
			MusicControl (off);
		}
	}

	public void ClickSoundButton () {
		if (GameObject.Find ("SoundButton") != null) {
			((AudioSource) GameObject.Find("SoundButton").GetComponent<AudioSource>()).Play();
		}

		if (soundButton.isOn) {
			print ("SOUND ON");
			PlayerPrefs.SetInt ("sound", on);
			SoundControl (on);
		} else {
			print ("SOUND OFF");
			PlayerPrefs.SetInt ("sound", off);
			SoundControl (off);
		}
	}


	// **************************************************** SETTINGS CHANGES *************************************************************************
	private void MusicControl (int value) {
		if (value == 1) {
			soundMusicMenu.mute = false;
			musicButton.isOn = true;
		} else {
			soundMusicMenu.mute = true;
			musicButton.isOn = false;
		}
	}

	private void SoundControl (int value) {
		if (value == 1) {
			soundButtonClick.mute = false;
			soundTapClick.mute = false;
			soundButton.isOn = true;
		} else {
			soundButtonClick.mute = true;
			soundTapClick.mute = true;
			soundButton.isOn = false;
		}
	}
}
