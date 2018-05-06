using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour {

    public bool announceDeath;
    public bool dropLoot;
    public List<Loot> loots;

    private LevelUIController levelUi;

    private void Awake() {
        levelUi = FindObjectOfType<LevelUIController>();
        if (levelUi == null) {
            Debug.LogError("Cannot find Level Controller");
        }
    }

    public void Execute() {
        if (announceDeath) {
            AnnounceDeath();
        }

        if (dropLoot) {
            DropLoot();
        }
    }

    public void DropLoot() {
        Transform transform = GetComponent<Transform>();
        int lootIndex = UnityEngine.Random.Range(0, loots.Count);
        float dice = UnityEngine.Random.Range(0, 100f);
        float chance = loots[lootIndex].chance;
        chance = chance > 1 ? chance : chance * 100;
        if (dice <= chance) {
            Components.ItemName itemName = loots[lootIndex].item;
            GameObject dropLoot = levelUi.GetLootDropObject(itemName);
            Instantiate(dropLoot, transform.position, Quaternion.identity);
        }
    }

    public void AnnounceDeath() {
        if (gameObject.tag == "Player") {
            Event.TriggerEvent(Event.GameEvent.PlayerDead);
        } else if (gameObject.tag == "Enemy") {
            Event.TriggerEvent(Event.GameEvent.BossDead);
        }
    }

    [Serializable]
    public struct Loot {
        public Components.ItemName item;
        public float chance;
    }
}
