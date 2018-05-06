using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopController : MonoBehaviour {

    public GridLayoutGroup inventoryPanel, bodyPanel;
    public VerticalLayoutGroup leftWeaponPanel, rightWeaponPanel;
    public WorkshopIconMap[] iconMap;

    private Inventory inventory;
    private HashSet<Components.ItemName> availableWeapon;
    private HashSet<Components.ItemName> availableBody;

    private void Awake() {
        inventory = FindObjectOfType<Inventory>();
        if (inventory == null) {
            Debug.LogError("Cannot find player inventory.");
        }

        availableWeapon = new HashSet<Components.ItemName>() {
            Components.ItemName.BulletDamage,
            Components.ItemName.BulletSize,
            Components.ItemName.BulletSpeed,
            Components.ItemName.DamageOnContact,
            Components.ItemName.Explosion,
            Components.ItemName.FiringRate,
            Components.ItemName.Homing,
            Components.ItemName.Pierce,
            Components.ItemName.Spread
        };

        availableBody = new HashSet<Components.ItemName>() {
            Components.ItemName.Health,
            Components.ItemName.MovementSpeed,
            Components.ItemName.DamageOnContact
        };
    }
    void Start () {
        Dictionary<Components.ItemName, GameObject> itemPrefabs = new Dictionary<Components.ItemName, GameObject>();
        foreach(WorkshopIconMap icon in iconMap) {
            itemPrefabs.Add(icon.itemName, icon.prefab);
        }
        SetWorkshopInventory(inventory.GetWorkshopInventory(), itemPrefabs);
        SetInstalledComponents(inventory.GetInstalledComponents(), itemPrefabs);
	}

    private void SetWorkshopInventory(IDictionary<Components.ItemName, int> workshopItems, IDictionary<Components.ItemName, GameObject> itemPrefabs) {
        int currentIndex = 0;
        foreach (KeyValuePair<Components.ItemName, int> item in workshopItems) {
            Transform itemSlot = inventoryPanel.transform.GetChild(currentIndex).transform;
            Instantiate(itemPrefabs[item.Key], itemSlot);
            itemSlot.GetComponentInChildren<Text>().text = item.Value.ToString();
            currentIndex++;
        }
    }

    private void SetInstalledComponents(IDictionary<Components.ItemName, int> installedItems, IDictionary<Components.ItemName, GameObject> itemPrefabs) {
        ItemInstallSlot[] leftList = leftWeaponPanel.GetComponentsInChildren<ItemInstallSlot>();
        ItemInstallSlot[] rightList = rightWeaponPanel.GetComponentsInChildren<ItemInstallSlot>();

        int leftCounter = 0;
        int rightCounter = 0;
        int bodyCounter = 0;
        foreach(KeyValuePair<Components.ItemName, int> item in installedItems) {
            if (availableWeapon.Contains(item.Key)) {
                for(int i = 0; i < item.Value; ++i) {
                    Transform weaponSlot = null;
                    if (leftCounter < leftList.Length) {
                        weaponSlot = leftList[leftCounter].transform;
                        leftCounter++;
                    } else if (rightCounter < rightList.Length) {
                        weaponSlot = rightList[rightCounter].transform;
                        rightCounter++;
                    }
                    Instantiate(itemPrefabs[item.Key], weaponSlot);
                }
            } else if (availableBody.Contains(item.Key)) {
                for (int i = 0; i < item.Value; ++i) {
                    Transform bodySlot = bodyPanel.transform.GetChild(bodyCounter).transform;
                    Instantiate(itemPrefabs[item.Key], bodySlot);
                    bodyCounter++;
                }
            }
        }
    }
}

[Serializable]
public struct WorkshopIconMap {
    public Components.ItemName itemName;
    public GameObject prefab;
}
