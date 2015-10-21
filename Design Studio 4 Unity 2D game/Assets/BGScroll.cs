using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour {

    public float BGSpeed = 0.1f;
    public Renderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {


        Vector2 offset = new Vector2(0, Time.time * BGSpeed);

        renderer.material.mainTextureOffset = offset;

       
	}
}
