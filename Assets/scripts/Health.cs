using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int currentHealth;
	public int fullHealth;

	void Start() {
		currentHealth = fullHealth;
	}

	void Update() {
		if (currentHealth <= 0) {
			if (GetComponent<OnDeath>() != null) {
				GetComponent<OnDeath>().Execute();
			}
			Destroy(gameObject);
		}
	}

	public void DealDamage(int damage) {
		currentHealth -= damage;
	}

	public void Heal(int amount) {
		currentHealth += amount;
	}
}
