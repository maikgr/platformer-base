using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopController : MonoBehaviour {

    public GridLayoutGroup inventoryPanel;
    public WorkshopIconMap[] iconMap;

    private Inventory inventory;

    private void Awake() {
        inventory = FindObjectOfType<Inventory>();
        if (inventory == null) {
            Debug.LogError("Cannot find player inventory.");
        }
    }
    void Start () {
        Dictionary<Components.ItemName, GameObject> itemPrefabs = new Dictionary<Components.ItemName, GameObject>();
        foreach(WorkshopIconMap icon in iconMap) {
            itemPrefabs.Add(icon.itemName, icon.prefab);
        }

        int currentIndex = 0;
        IDictionary<Components.ItemName, int> workshopItems = inventory.GetWorkshopInventory();
        foreach(KeyValuePair<Components.ItemName, int> item in workshopItems) {
            Transform itemSlot = inventoryPanel.transform.GetChild(currentIndex).transform;
            Instantiate(itemPrefabs[item.Key], itemSlot);
            itemSlot.GetComponentInChildren<Text>().text = item.Value.ToString();
            currentIndex++;
        }
	}
}

[Serializable]
public struct WorkshopIconMap {
    public Components.ItemName itemName;
    public GameObject prefab;
}
