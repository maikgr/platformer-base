using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int currentHealth;
	public int fullHealth;
	public bool announceHealth;
    public GameObject ExplosionPrefab;

	private HealthEvent healthEvent;
    private LevelUIController levelUi;

	void Start() {
		Init ();

		if (announceHealth) {
			healthEvent = GetComponent<HealthEvent> ();
		}
        if (transform.GetComponent<PlayerController>() != null) {
            levelUi = FindObjectOfType<LevelUIController>();
        }
	}

	protected virtual void Init() {
		currentHealth = fullHealth;
	}

	void Update() {
		if (currentHealth <= 0) {
			GetComponent<OnDeath>().Execute();
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		if (announceHealth) {
			healthEvent.announceHealth (currentHealth);
		}
	}

	public void DealDamage(int damage) {
		currentHealth -= damage;
        UpdateHealthBar();
    }

	public void Heal(int amount) {
		currentHealth += amount;
        UpdateHealthBar();
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
        UpdateHealthBar();
    }

    public void UpdateHealthBar() {
        if(levelUi != null) {
            levelUi.UpdateHealth(currentHealth);
        }
    }
}
