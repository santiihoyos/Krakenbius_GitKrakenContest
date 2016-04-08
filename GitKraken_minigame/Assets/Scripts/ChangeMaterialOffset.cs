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
        if (Mathf.Abs(offset.x) >= 1)
            offset.x -= Mathf.Sign(offset.x);
        if (Mathf.Abs(offset.y) >= 1)
            offset.y -= Mathf.Sign(offset.y);
        mat.mainTextureOffset = offset;
	}
}
