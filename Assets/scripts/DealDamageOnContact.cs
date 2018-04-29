using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnContact : MonoBehaviour {

	public int damage;
	public bool isPlayer; 

	bool isColliding = false;

	void OnTriggerEnter (Collider other)
	{
		if (isColliding)
			return;

		isColliding = true;
		if (IsOpponent (other.tag)) {
			other.GetComponent<Health> ().DealDamage (damage);
		}
	}

	bool IsOpponent(string tagName) {
		if (isPlayer)
			return (tagName == "Enemy" || tagName == "Boss");
		else
			return tagName == "Player";
				
	}

	void Update() {
		isColliding = false;
	}


}
