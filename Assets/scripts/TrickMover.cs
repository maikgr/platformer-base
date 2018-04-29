using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickMover : MonoBehaviour {
	
	public float speed;
	private Rigidbody rigidbody;
	public float xMax = 19, xStart = -17;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		Vector3 dir = transform.right;
		dir.Normalize ();
		rigidbody.velocity = dir * speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= xMax) {
			transform.position = new Vector3 (xStart, transform.position.y, 0);
		}
	}
}
