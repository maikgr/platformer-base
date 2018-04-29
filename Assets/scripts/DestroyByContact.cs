using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public bool isPlayer;

	void OnTriggerEnter (Collider other) 
	{
		if (IsOpponent(other.tag))
			Destroy(gameObject);
	}

	bool IsOpponent(string tagName) {
		if (isPlayer)
			return (tagName == "Enemy" || tagName == "Boss");
		else
			return tagName == "Player";

	}
}
