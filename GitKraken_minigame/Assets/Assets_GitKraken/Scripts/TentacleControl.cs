using UnityEngine;
using System.Collections;

public class TentacleControl : MonoBehaviour {

	public GameObject newTentacle;
	public float branchIncrease = 5f;

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Branch") {
			//Instantiate (newTentacle);
			// Instanciar un nuevo tentaculo donde corresponda

		} else if (coll.gameObject.tag == "Commit") {
			//this.transform.Translate (Vector3.down * (branchIncrease / 2));

			this.transform.localScale = new Vector3 (this.transform.localScale.x, this.transform.localScale.y + branchIncrease, this.transform.localScale.z);

		} else if (coll.gameObject.tag == "Conflict") {
			Destroy (this.gameObject);

		} else if (coll.gameObject.tag == "Merge") {
			// Parpadeo de la rama y al coger otro merge en otra se combinan

		} else if (coll.gameObject.tag == "Pull") {
			this.transform.localScale = new Vector3 (this.transform.localScale.x, this.transform.localScale.y + (branchIncrease * 3), this.transform.localScale.z);

		} else if (coll.gameObject.tag == "Push") {
			this.transform.localScale = new Vector3 (this.transform.localScale.x, this.transform.localScale.x, this.transform.localScale.z);

		} else if (coll.gameObject.tag == "Rebase") {
			GameObject[] tentacles = GameObject.FindGameObjectsWithTag("Tentacle");

			for (int i = 0; i < tentacles.Length; i++) {
				tentacles[i].transform.localScale = new Vector3 (this.transform.localScale.x, this.transform.localScale.x, this.transform.localScale.z);
			}
		}
	}
}
