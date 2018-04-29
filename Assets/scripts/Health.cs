using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int currentHealth;
	public int fullHealth;
	public bool announceHealth;
    public GameObject ExplosionPrefab;

	private HealthEvent healthEvent;

	void Start() {
		Init ();

		if (announceHealth) {
			healthEvent = GetComponent<HealthEvent> ();
		}
	}

	protected virtual void Init() {
		currentHealth = fullHealth;
	}

	void Update() {
		if (currentHealth <= 0) {
			if (GetComponent<OnDeath>() != null) {
				GetComponent<OnDeath>().Execute();
			}
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (announceHealth) {
			healthEvent.announceHealth (currentHealth);
		}
	}

	public void DealDamage(int damage) {
		currentHealth -= damage;
	}

	public void Heal(int amount) {
		currentHealth += amount;
	}

	public int GetHealth() {
		return currentHealth;
	}

	public int GetFullHealth() {
		return fullHealth;
	}

	public void SetFullHealth(int hp) {
		fullHealth = hp;
		Init ();
	}
}
