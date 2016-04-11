using UnityEngine;
using System.Collections;

public class KrakenControl : MonoBehaviour {

	public static int score;
	GameObject kraken;
	bool buttonLeft_pressed;
	bool buttonRight_pressed;

	// Use this for initialization
	void Start () {
		kraken = GameObject.Find ("Kraken");
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			RotateLeft ();
		} else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			RotateRight ();
		}
	}

	public void ButtonLeft () {
		
	}

	public void ButtonRight () {

	}

	void RotateLeft() {		
		kraken.gameObject.transform.Rotate (Vector3.forward * 200f * Time.deltaTime);
	}

	void RotateRight() {		
		kraken.gameObject.transform.Rotate (Vector3.back * 200f * Time.deltaTime);
	}
}
