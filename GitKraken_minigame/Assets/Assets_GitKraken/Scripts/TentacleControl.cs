using UnityEngine;
using System.Collections;

public class TentacleControl : MonoBehaviour {

	public GameObject newTentacle;
	public float branchIncrease = 5f;

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Branch") {
			GameObject[] tentacles = GameObject.FindGameObjectsWithTag("Tentacle");

			for (int i = 0; i < tentacles.Length; i++) {
				if (tentacles [i].transform.GetChild (0).gameObject.activeSelf == false) {
					tentacles [i].transform.GetChild (0).gameObject.SetActive (true);
					break;
				};
			}

		} else if (coll.gameObject.tag == "Commit") {
			this.transform.parent.localScale = new Vector3 (this.transform.parent.localScale.x, this.transform.parent.localScale.y + branchIncrease, this.transform.parent.localScale.z);

		} else if (coll.gameObject.tag == "Conflict") {			
			this.transform.parent.localScale = new Vector3 (this.transform.parent.localScale.x, this.transform.parent.localScale.x, this.transform.parent.localScale.z);
			this.gameObject.SetActive (false);

		} else if (coll.gameObject.tag == "Merge") {
			// Parpadeo de la rama y al coger otro merge en otra se combinan

		} else if (coll.gameObject.tag == "Pull") {
			this.transform.parent.localScale = new Vector3 (this.transform.parent.localScale.x, this.transform.parent.localScale.y + (branchIncrease * 3), this.transform.parent.localScale.z);

		} else if (coll.gameObject.tag == "Push") {
			this.transform.parent.localScale = new Vector3 (this.transform.parent.localScale.x, this.transform.parent.localScale.x, this.transform.parent.localScale.z);

		} else if (coll.gameObject.tag == "Rebase") {
			GameObject[] tentacles = GameObject.FindGameObjectsWithTag("Tentacle");

			for (int i = 0; i < tentacles.Length; i++) {
				if (i <= 3) {
					tentacles [i].transform.GetChild (0).gameObject.SetActive (true);
				} else {
					tentacles [i].transform.GetChild (0).gameObject.SetActive (false);
				}
				tentacles[i].transform.localScale = new Vector3 (this.transform.parent.localScale.x, this.transform.parent.localScale.x, this.transform.parent.localScale.z);
			}
		}
	}
}
