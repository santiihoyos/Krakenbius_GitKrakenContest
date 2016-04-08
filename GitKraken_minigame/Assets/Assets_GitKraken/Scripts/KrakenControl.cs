using UnityEngine;
using System.Collections;

public class KrakenControl : MonoBehaviour {

	public static int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) {
			this.gameObject.transform.Rotate (Vector3.forward * 200f * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.D)) {
			this.gameObject.transform.Rotate (Vector3.back * 200f * Time.deltaTime);
		}
	}
}
