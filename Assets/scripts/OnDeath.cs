using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour {

	public bool announceDeath;
	public bool dropLoot;
	public GameObject[] loot;
	public float[] lootChance;

	public void Execute() {
		if (announceDeath) {
			AnnounceDeath ();
		}

		if (dropLoot) {
			DropLoot ();
		}
	}

	public void DropLoot() {
		Transform transform = GetComponent<Transform> ();
		bool drop;
		for (int i = 0; i < loot.Length; i++) {
			drop = (Random.Range(0, 101) <= lootChance[i] * 100);
			if (drop) {
				Instantiate (loot [i], transform.position, Quaternion.identity);
			}
		}
	}

	public void AnnounceDeath() {
		if (gameObject.tag == "Player") {
			Event.TriggerEvent (Event.GameEvent.PlayerDead);
		} else if (gameObject.tag == "Boss") {
			Event.TriggerEvent (Event.GameEvent.BossDead);
		}
	}
}
