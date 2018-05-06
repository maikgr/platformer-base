using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour {

	public Components.ItemName itemName;

	private AudioSource pickSfx;
	private Inventory inventory;
    private LevelUIController levelUi;

	void Start() {
		inventory = GameObject.Find("Inventory").GetComponent<Inventory> ();
        levelUi = FindObjectOfType<LevelUIController>();
		pickSfx = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			pickSfx.Play();
            foreach(SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>()) {
                renderer.enabled = false;
            }
			inventory.AddToCargo (itemName);
            levelUi.UpdateLoot(itemName);
			Destroy (gameObject, pickSfx.clip.length);
		}
	}
}