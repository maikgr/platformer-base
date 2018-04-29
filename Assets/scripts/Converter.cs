using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour {

	public Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
