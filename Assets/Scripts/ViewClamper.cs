using UnityEngine;
using System.Collections;

public class ViewClamper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        clampToViewBoundaries();
        clampToGround();
	}


    void clampToViewBoundaries()
    {
        // clamp to boundaries
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void clampToGround()
    {
        // clamp to boundaries
        Vector3 pos = transform.position;
        pos.y = Mathf.Max(transform.localScale.y * 0.5f, pos.y);
        transform.position = pos;
    }
}
