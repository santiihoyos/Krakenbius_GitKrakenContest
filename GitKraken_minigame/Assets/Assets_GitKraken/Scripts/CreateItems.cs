using UnityEngine;
using System.Collections;

public class CreateItems : MonoBehaviour {

	public GameObject item_conflict;
	public GameObject item_branch;
	public GameObject item_commit;
	public GameObject item_push;
	public GameObject item_pull;
	public GameObject item_merge;
	public GameObject item_rebase;
	float seconds;
	int level;

	// Use this for initialization
	void Start () {
		seconds = 1f;
		level = 1;
		StartCoroutine (GenerateItem());
	}

	IEnumerator GenerateItem() {
		
		for (;;) {
			int r = Random.Range(1, 101);

			if (r >= 1 && r <= 20)
				Instantiate (item_commit);
			else if (r >= 21 && r <= 29)
				Instantiate (item_pull);
			else if (r >= 30 && r <= 45)
				Instantiate (item_push);
			else if (r >= 46 && r <= 55)
				Instantiate (item_merge);
			else if (r >= 56 && r <= 60)
				Instantiate (item_branch);
			else if (r >= 61 && r <= 65)
				Instantiate (item_rebase);
			else if (r >= 66 && r <= 100)
				Instantiate (item_conflict);


			if (KrakenControl.score >= 200 * Mathf.Pow(2, level) && seconds > 0f) {
				level++;
				seconds -= 0.1f;
				print ("Nuevo nivel!! Item cada " + seconds + " segundos");
			}

			yield return new WaitForSeconds (seconds);
		}
	}
}
