using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateItems : MonoBehaviour {

	public GameObject item_conflict;
	public GameObject item_branch;
	public GameObject item_commit;
	public GameObject item_push;
	public GameObject item_pull;
	public GameObject item_merge;
	public GameObject item_rebase;
	public GameObject version_value;
    public GameObject nextVersionEffectPrefab;
	public GameObject rebaseDummyEffectPrefab;

	public int version; // fase
	public int level; // level of fase
	public static float speed;
	float seconds;

	// Use this for initialization
	void Start () {
		version = 1;
		level = 0;
		speed = 1f;
		seconds = 1f;
		version_value.GetComponent<Text>().text = "v " + version.ToString() + "." + level.ToString();
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
			else if (r >= 61 && r <= 63)
				Instantiate (item_rebase);
			else if (r >= 64 && r <= 100)
				Instantiate (item_conflict);

			if (krakenScripts.KrakenControl.score >= ((version - 1) * (500 * Mathf.Pow (1.5f, 10))) + (500 * Mathf.Pow (1.5f, level + 1))) {
				level++;

				if (level == 10) {
					NextVersion ();
				} 
				else {
					seconds -= 0.1f;
				}
				version_value.GetComponent<Text> ().text = "v " + version.ToString () + "." + level.ToString ();
				print ("Level Up!! Version = " + version + ", Level = " + level + ", Speed = " + speed + ", Seconds = " + seconds);
			}

			yield return new WaitForSeconds (seconds);
		}
	}

	void NextVersion () {
		version ++;
		level = 0;
		speed += 0.2f;
		seconds = 1f;
		ItemControl[] items = GameObject.FindObjectsOfType<ItemControl> ();
		for (int i = items.Length - 1; i >= 0; i--) {
			if (items[i].gameObject.tag == "Rebase") 
			{
				Instantiate (rebaseDummyEffectPrefab, items[i].transform.position, Quaternion.identity);
			} 
			else {
				items[i].Explosion ();
			}
			Destroy (items [i].gameObject);
		}
        Instantiate(nextVersionEffectPrefab, transform.position + new Vector3(0, -3, -1), Quaternion.identity);
	}
}
