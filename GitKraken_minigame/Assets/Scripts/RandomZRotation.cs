using UnityEngine;
using System.Collections;

public class RandomZRotation : MonoBehaviour {

    public float minRotationSpeed=20;
    public float maxRotationSpeed = 50;


    float rotationSpeed;
    float timeRotating;
    int rotationDirection = 1;
    void Start()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        timeRotating = Random.Range(5,20f);
        StartCoroutine(ChangeRotation());
    }
	
	void Update ()
    {
        transform.Rotate(0,0,rotationDirection*rotationSpeed*Time.deltaTime);
	}

    IEnumerator ChangeRotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeRotating);
            rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
            timeRotating = Random.Range(0, 20f);
            rotationDirection = -rotationDirection;
        }

    }
}
