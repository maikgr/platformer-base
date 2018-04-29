using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInstallSlot : MonoBehaviour, IDropHandler {

    public List<Components.ItemName> installableItems;

    private Inventory inventory;
    private WorkshopShipComponent installedItem;

    void Awake() {
        inventory = FindObjectOfType<Inventory>();
        if (inventory == null) {
            Debug.LogError("Cannot find player inventory.");
        }
    }

    public GameObject Item {
        get {
            if (transform.GetComponentInChildren<ItemDragHandler>()) {
                return transform.GetComponentInChildren<ItemDragHandler>().gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        if (!Item) {
            GameObject heldItem = ItemDragHandler.heldItem;
            Components.ItemName heldItemName = heldItem.GetComponent<WorkshopShipComponent>().itemName;
            if (installableItems.Contains(heldItemName)) {
                heldItem.transform.SetParent(transform);
                Item.transform.localPosition = Vector3.zero;
                inventory.InstallComponent(heldItemName);
                installedItem = heldItem.GetComponent<WorkshopShipComponent>();
            }
        }
    }

    void Update() {
        if (Input.GetMouseButtonUp(0)) {
            if (installedItem != null && !Item) {
                inventory.UninstallComponent(installedItem.itemName);
                installedItem = null;
            }
        }
    }
}
