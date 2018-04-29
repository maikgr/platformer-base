using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed;
	public Transform target;

	// Update is called once per frame
	void Update () {
		target.Rotate(Vector3.forward, speed * Time.deltaTime);
	}
}
