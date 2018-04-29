using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEvent : MonoBehaviour {

	public float healthPercentage1;
	public float healthPercentage2;  // 2 is the smaller one

	private int healthThreshold1, healthThreshold2;
	private Health health;

	private int state = 0;

	// Use this for initialization
	void Start () {
		health = GetComponent<Health> ();
		int fullHealth = health.GetFullHealth ();
		healthThreshold1 = Mathf.RoundToInt (healthPercentage1 * fullHealth);
		healthThreshold2 = Mathf.RoundToInt (healthPercentage2 * fullHealth);
	}
		
	public void announceHealth(int curr) {
		if (state == 1 && curr <= healthThreshold2) {
			Event.TriggerEvent (Event.GameEvent.BossHealth2);
			state++;
		}
		else if (state == 0 && curr<= healthThreshold1) {
			Event.TriggerEvent (Event.GameEvent.BossHealth1);
			state++;
		}
	}
}
