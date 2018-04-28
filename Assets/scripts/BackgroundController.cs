using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 initialPos;

	void Start () {
        initialPos = transform.position;
	}
	
	void Update () {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = initialPos + Vector3.left * newPos;
	}
}
