using UnityEngine;
using System.Collections;

public class ItemControl : MonoBehaviour {

	GameObject kraken;
	public float deathDistance = 0.5f;
	float initScale = 0.5f;
	float finalScale = 0.2f;
	Vector3 initPos;
	Vector3 finalPos;
	float timeToDie;
	float spendTime=0;

	// Use this for initialization
	public void Init (GameObject kraken,float speed) {
		this.kraken = kraken;

		float r = Random.Range(0f, 360f);
		transform.position = new Vector3 (Mathf.Sqrt (50), 0, 0);
		transform.RotateAround(new Vector3(0,0,0), Vector3.forward, r);
		initPos = transform.position;

		Vector3 direction = (kraken.transform.position - initPos);
		finalPos = kraken.transform.position - deathDistance * direction.normalized;
		timeToDie = (initPos - finalPos).magnitude/speed;
	}
	
	// Update is called once per frame
	void Update () {
		spendTime += Time.deltaTime;

		//*********** RESCALE ITEM ***********
		this.transform.localScale = Vector3.Lerp (initScale * Vector3.one, finalScale * Vector3.one, spendTime / timeToDie);

		//*********** FOLLOW KRAKEN ***********
		this.transform.position = Vector3.Lerp (initPos, finalPos, spendTime / timeToDie);

		if (spendTime >= timeToDie) {
			Destroy (this.gameObject);
		}
	}
}
