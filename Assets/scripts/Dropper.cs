using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour {

	public float frequency;
	public GameObject item;

	private Transform me;

	// Use this for initialization
	void Start () {
		me = GetComponent<Transform>();
		InvokeRepeating ("DropItem", frequency, frequency);
	}

	void DropItem () {
		Instantiate (item, me.position, Quaternion.identity);
	}



}
