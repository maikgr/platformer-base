using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	
	public GameObject shot;
	public Transform[] shotSpawn;

	public float weaponDelay; // delay between each spawn point (if multiple)
	public float initialDelay;


	void Start() {
		StartCoroutine ("Fire");
	}

	IEnumerator Fire() {
		yield return new WaitForSeconds (initialDelay);
			
		for (int i = 0; i < shotSpawn.Length; i++) {
			Instantiate (shot, shotSpawn[i].position, shotSpawn[i].rotation);
			yield return new WaitForSeconds (weaponDelay);
		}

		Destroy (gameObject);
	}
}
