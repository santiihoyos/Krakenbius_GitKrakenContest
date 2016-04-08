using UnityEngine;
using System.Collections;

public class DieAfterTime : MonoBehaviour {

    public float TimeToDie = 2;

	void Start ()
    {
        StartCoroutine(CountDown());
	}
	
	IEnumerator CountDown()
    {
        yield return new WaitForSeconds(TimeToDie);
        Destroy(gameObject);
	}
}
