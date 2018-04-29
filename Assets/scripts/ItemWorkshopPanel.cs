using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemWorkshopPanel : MonoBehaviour {

    public void PutIntoWorkshopInventory() {
        bool updated = false;
        GameObject heldItem = ItemDragHandler.heldItem;
        Components.ItemName heldItemName = heldItem.GetComponent<WorkshopShipComponent>().itemName;
        foreach (Transform itemSlot in transform) {
            WorkshopShipComponent component = itemSlot.GetComponentInChildren<WorkshopShipComponent>();
            if(component != null && component.itemName.Equals(heldItemName)) {
                int quantity = int.Parse(itemSlot.GetComponentInChildren<Text>().text) + 1;
                itemSlot.GetComponentInChildren<Text>().text = quantity.ToString();
                Destroy(heldItem);
                updated = true;
                break;
            }
        }

        if (!updated) {
            foreach (Transform itemSlot in transform) {
                WorkshopShipComponent component = itemSlot.GetComponentInChildren<WorkshopShipComponent>();
                if(component == null) {
                    heldItem.transform.SetParent(itemSlot);
                    heldItem.transform.localPosition = Vector3.zero;
                    heldItem.GetComponent<CanvasGroup>().blocksRaycasts = true;
                    itemSlot.GetComponentInChildren<Text>().text = "1";
                    break;
                }
            }
        }
    }
}
