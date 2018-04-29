using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternMover : MonoBehaviour {
	
	float timeCounter = 0;

	public Transform target;
	public float speed;
	public float width;
	public float height;

	public float numPeaks;

	private float originX;
	private float originY;

	float x,y,z;

	// Use this for initialization
	void Start () {
		originX = target.position.x;
		originY = target.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime*speed;

		x = originX + Mathf.Cos (timeCounter) * width;
		y = originY + Mathf.Sin (numPeaks*timeCounter) * height;
		z = 0;

		target.position = new Vector3 (x, y, z);
	}
}
