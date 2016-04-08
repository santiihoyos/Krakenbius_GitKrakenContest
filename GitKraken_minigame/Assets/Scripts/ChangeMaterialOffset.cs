using UnityEngine;
using System.Collections;

public class ChangeMaterialOffset : MonoBehaviour {

    public Vector2 offsetSpeed=new Vector2(0,0.01f);

    Material mat;

    void Start()
    {
        mat = new Material(GetComponent<Renderer>().material);
        GetComponent<Renderer>().material = mat;
    }
	void Update ()
    {
        Vector2 offset = mat.mainTextureOffset;
        offset += offsetSpeed * Time.deltaTime;
        offset.x = Mathf.Clamp(offset.x, 0, 1);
        offset.y = Mathf.Clamp(offset.y,0, 1);
        mat.mainTextureOffset = offset;
	}
}
