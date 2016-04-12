using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace krakenScripts{
public class KrakenControl : MonoBehaviour {

	public static int score;
	GameObject kraken;
	public GameObject score_value;
	bool buttonLeft_pressed;
	bool buttonRight_pressed;

	// Use this for initialization
	void Start () {
		kraken = GameObject.Find ("Kraken");
		score = 0;
		score_value.GetComponent<Text>().text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (buttonLeft_pressed) {
			RotateLeft ();
		} else if (buttonRight_pressed) {
			RotateRight ();
		} else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			RotateLeft ();
		} else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			RotateRight ();
		}
		score_value.GetComponent<Text>().text = score.ToString();
	}

	public void ButtonLeftDown () {
		buttonLeft_pressed = true;
	}

	public void ButtonRightDown () {
		buttonRight_pressed = true;
	}

	public void ButtonLeftUp () {
		buttonLeft_pressed = false;
	}

	public void ButtonRightUp () {
		buttonRight_pressed = false;
	}

	void RotateLeft() {	
		if (kraken != null)	
			kraken.gameObject.transform.Rotate (Vector3.forward * 200f * Time.deltaTime);
	}

	void RotateRight() {	
		if (kraken != null)
			kraken.gameObject.transform.Rotate (Vector3.back * 200f * Time.deltaTime);
	}
}
}
