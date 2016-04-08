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
	int count = 0;

	// Use this for initialization
	void Start () {
		seconds = 1f;
		StartCoroutine (GenerateItem());
	}

	IEnumerator GenerateItem() {
		
		for (;;) {
			int r = Random.Range(1, 101);

			if (r >= 1 && r <= 29)
				Instantiate (item_commit);
			else if (r >= 30 && r <= 39)
				Instantiate (item_pull);
			else if (r >= 40 && r <= 49)
				Instantiate (item_push);
			else if (r >= 50 && r <= 54)
				Instantiate (item_merge);
			else if (r >= 55 && r <= 59)
				Instantiate (item_branch);
			else if (r >= 60 && r <= 65)
				Instantiate (item_rebase);
			else if (r >= 65 && r <= 100)
				Instantiate (item_conflict);

			count++;

			if (count % 20 == 0 && seconds > 0f) {
				seconds -= 0.1f;
				print ("Items generados: " + count + ", Uno nuevo cada " + seconds + " segundos");
			}

			yield return new WaitForSeconds (seconds);
		}
	}
}
