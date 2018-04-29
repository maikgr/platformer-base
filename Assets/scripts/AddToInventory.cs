using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour {

	public Components.ItemName itemName;

	private Inventory inventory;

	void Start() {
		inventory = GameObject.Find("Inventory").GetComponent<Inventory> ();
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			inventory.AddToCargo (itemName);
			Destroy (gameObject);
		}
	}


}
