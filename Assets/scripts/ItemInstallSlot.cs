using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInstallSlot : MonoBehaviour, IDropHandler {

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
            ItemDragHandler.heldItem.transform.SetParent(transform);
            Item.transform.localPosition = Vector3.zero;
        }
    }
}
