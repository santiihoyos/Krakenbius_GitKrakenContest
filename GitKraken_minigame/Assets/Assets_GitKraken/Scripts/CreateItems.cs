using UnityEngine;
using System.Collections;

public class CreateItems : MonoBehaviour {

	//public GameObject kraken;

	// Use this for initialization
	void Start () {
		ItemControl item = new ItemControl ();
		item.Init (this.gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
