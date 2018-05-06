using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour {

    public RectTransform healthPanel;
    public float healthBarSizeInPixel;
    public GridLayoutGroup lootPanel;
    public GameObject itemLootSlot;
    public GameObject dropLoot;
    public List<ItemLootIcon> iconList;    

    private Dictionary<Components.ItemName, int> lootMap;
    private Dictionary<Components.ItemName, Sprite> iconMap;
    private int nextIndex;

    private void Awake() {
        lootMap = new Dictionary<Components.ItemName, int>();
        iconMap = new Dictionary<Components.ItemName, Sprite>();
        nextIndex = 0;

        foreach(ItemLootIcon icon in iconList) {
            iconMap.Add(icon.item, icon.icon);
        }
    }

    public void UpdateHealth(int currentHealth) {
        healthPanel.sizeDelta = new Vector2(currentHealth * healthBarSizeInPixel, healthPanel.sizeDelta.y);
    }

    public void UpdateLoot(Components.ItemName item) {
        int index;
        if(lootMap.TryGetValue(item, out index)){
            UpdateExistingLoot(index);
        } else {
            AddNewLoot(item);
            lootMap.Add(item, nextIndex);
            nextIndex++;
        }
    }

    public GameObject GetLootDropObject(Components.ItemName item) {
        Debug.Log("Loot: " + item.ToString());
        dropLoot.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = iconMap[item];
        dropLoot.GetComponent<AddToInventory>().itemName = item;
        return dropLoot;
    }

    private void UpdateExistingLoot(int index) {
        Transform loot = lootPanel.transform.GetChild(index);
        Text lootAmount = loot.GetComponentInChildren<Text>();
        int quantity = int.Parse(lootAmount.text) + 1;
        lootAmount.text = quantity.ToString();
    }

    private void AddNewLoot(Components.ItemName item) {
        GameObject newLoot = Instantiate(itemLootSlot, lootPanel.transform);
        newLoot.transform.GetChild(0).GetComponent<Image>().sprite = iconMap[item];
        newLoot.GetComponentInChildren<Text>().text = "1";
    }

    [Serializable]
    public struct ItemLootIcon {
        public Components.ItemName item;
        public Sprite icon;
    }
}
