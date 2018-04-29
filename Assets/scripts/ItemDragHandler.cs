using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject heldItem;

    private Vector3 startPosition;
    private Transform startParent;
    private Transform canvas;

    public void OnBeginDrag(PointerEventData eventData) {
        heldItem = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        canvas = GameObject.FindGameObjectWithTag("UICanvas").transform;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(canvas);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        heldItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(transform.parent == canvas) {
            transform.position = startPosition;
            transform.parent = startParent;
        }        
    }    
}
