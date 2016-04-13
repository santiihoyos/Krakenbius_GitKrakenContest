using UnityEngine;
using System.Collections;
using System;

public class TentacleControl : MonoBehaviour {

	GameObject[] tentacles;
	float branchIncrease = 0.1f;
	int scoreIncrement = 100;
	public GameObject gameOver;
	GameObject rankingManager;

	void Start() {
		tentacles = GameObject.FindGameObjectsWithTag("Tentacle");
		Array.Sort (tentacles, CompareObNames);
		rankingManager = GameObject.Find ("rankingManager");
	}

	void OnCollisionEnter2D(Collision2D coll) {

		string tentagle_collision = coll.gameObject.tag;

		if (tentagle_collision == "Branch") { // Yellow
			krakenScripts.KrakenControl.score += scoreIncrement * 8;

			foreach (var item in tentacles) {
				if (item.transform.GetChild (0).gameObject.activeSelf == false) {
					item.transform.GetChild (0).gameObject.SetActive (true);
					break;
				};
			}

		} else if (tentagle_collision == "Commit") { // Cian
			krakenScripts.KrakenControl.score += scoreIncrement;
			this.transform.parent.localScale = new Vector3 (this.transform.parent.localScale.x, this.transform.parent.localScale.y + branchIncrease, 1);

		} else if (tentagle_collision == "Conflict") {	// Red	
			if (this.transform.parent.localScale.x > 1f) {
				this.transform.parent.localScale = new Vector3 (1, this.transform.parent.localScale.y, 1);
			} else {
				this.transform.parent.localScale = new Vector3 (1, 1, 1);
				this.gameObject.SetActive (false);
				bool any_active = false;
				print (any_active);
				for (int i = 0; i < tentacles.Length; i++) {
					if (tentacles [i].transform.GetChild (0).gameObject.activeSelf == true) {
						any_active = true;
						break;
					}
				}
				if (!any_active) {
                    GameOver();
				}
			}		

		} else if (tentagle_collision == "Merge") { // Purple
			krakenScripts.KrakenControl.score += scoreIncrement * 5;
			if (this.transform.parent.localScale.x == 1f) {
				this.transform.parent.localScale = new Vector3 (this.transform.parent.localScale.x + (branchIncrease * 5), this.transform.parent.localScale.y, 1);
			} 

		} else if (tentagle_collision == "Pull") { // Orange
			krakenScripts.KrakenControl.score += scoreIncrement * 3;
			this.transform.parent.localScale = new Vector3 (this.transform.parent.localScale.x, this.transform.parent.localScale.y + (branchIncrease * 3), 1);

		} else if (tentagle_collision == "Push") { // Green
			float calc_height = (this.transform.parent.localScale.y - 1f) * 10;

			krakenScripts.KrakenControl.score += 200 + (scoreIncrement * (int) calc_height);
			this.transform.parent.localScale = new Vector3 (this.transform.parent.localScale.x, 1, 1);

		} else if (tentagle_collision == "Rebase") { // White
			float calc_height = 0f;
			float calc_width = 0f;

			for (int i = 0; i < tentacles.Length; i++) {
				if (tentacles[i].transform.localScale.y > 1f) {
					calc_height += (tentacles[i].transform.localScale.y - 1f) * 10;
					calc_width += (tentacles[i].transform.localScale.x - 1f) * 10;
				}

				tentacles[i].transform.localScale = new Vector3 (1, 1, 1);

				if (i <= 3) {
					tentacles [i].transform.GetChild (0).gameObject.SetActive (true);
				} else {
					tentacles [i].transform.GetChild (0).gameObject.SetActive (false);
				}
			}
			krakenScripts.KrakenControl.score += 500 + (scoreIncrement * (int) calc_height) + (scoreIncrement * (int) calc_width);
		}

		print (krakenScripts.KrakenControl.score);
	}

    private void GameOver()
    {

		rankingManager.GetComponent<DialogRankingController>().FinalOfMatch ();
        Instantiate(gameOver);
        GameObject.FindObjectOfType<AudioManager>().PitchBase();
        GameObject.FindObjectOfType<HUDPanelController>().GameOver();
        Destroy (GameObject.Find("Kraken"));
    }

    int CompareObNames( GameObject x, GameObject y)
	{
		return x.name.CompareTo(y.name);
	}
}
