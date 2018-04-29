using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject heldItem;

    private Transform canvas;
    private Transform startParent;

    public void OnBeginDrag(PointerEventData eventData) {
        canvas = GameObject.FindGameObjectWithTag("UICanvas").transform;
        startParent = transform.parent;
        Text quantityText = startParent.GetComponentInChildren<Text>();

        if (quantityText != null && GetQuantity() > 1) {
            AddQuantity(-1);
            heldItem = Instantiate(gameObject, canvas);
        } else if(quantityText != null && GetQuantity() == 1 ) {
            AddQuantity(-1);
            heldItem = gameObject;
            gameObject.transform.SetParent(canvas);
        } else {
            heldItem = gameObject;
            gameObject.transform.SetParent(canvas);
        }

        heldItem.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        heldItem.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {        
        if(heldItem.transform.parent == canvas) {
            GameObject panel = GameObject.FindGameObjectWithTag("InventoryPanel");
            panel.GetComponent<ItemWorkshopPanel>().PutIntoWorkshopInventory();
        } else {
            heldItem.transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    private void AddQuantity(int addAmount) {
        Text quantityText = startParent.GetComponentInChildren<Text>();
        int quantity = GetQuantity() + addAmount;

        if(quantity > 0) {
            quantityText.text = quantity.ToString();
        } else if (quantity <= 0) {
            quantityText.text = "";
        }
    }

    private int GetQuantity() {
        int quantity;
        Text parentText = startParent.GetComponentInChildren<Text>();
        if (parentText != null && int.TryParse(parentText.text, out quantity)) {
            return quantity;
        }
        return 0;
    }
}
