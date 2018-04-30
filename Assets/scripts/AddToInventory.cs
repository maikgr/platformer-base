using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour {

	public Components.ItemName itemName;

	private AudioSource pickSfx;
	private Inventory inventory;

	void Start() {
		inventory = GameObject.Find("Inventory").GetComponent<Inventory> ();
		pickSfx = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			pickSfx.Play();
			inventory.AddToCargo (itemName);
			Destroy (gameObject);
		}
	}


}
