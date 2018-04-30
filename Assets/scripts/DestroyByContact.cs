using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public bool isPlayer;
	public int pierce = 0;

	void OnTriggerEnter (Collider other) 
	{
		if (IsOpponent (other.tag)) {
			if (pierce == 0) 
				Destroy (gameObject);
			else {
				pierce--;
			}
		}

	}

	bool IsOpponent(string tagName) {
		if (isPlayer)
			return (tagName == "Enemy" || tagName == "Boss");
		else
			return tagName == "Player";

	}
}
