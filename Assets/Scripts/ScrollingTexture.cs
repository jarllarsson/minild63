using UnityEngine;
using System.Collections;

public class ScrollingTexture : MonoBehaviour {

	public float scrollSpeed = 0.1f;
	public Material materialToScroll;

	private float currentScroll = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		currentScroll += Time.deltaTime * scrollSpeed;
		materialToScroll.SetTextureOffset("_MainTex", new Vector2(0.0f, currentScroll));
	}

	void OnDestroy () {
		materialToScroll.SetTextureOffset("_MainTex", new Vector2(0.0f, 0.0f));
	}
}
