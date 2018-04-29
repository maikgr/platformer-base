using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WorkshopShipComponent : MonoBehaviour, IPointerDownHandler {

    public Components.ItemName itemName;
    public string componentName;
    public string componentDescription;

    private Text panelName;
    private Text panelDescription;

    private void Awake() {
        GameObject description = GameObject.FindGameObjectWithTag("DescriptionPanel");
        panelName = description.transform.GetChild(0).GetComponent<Text>();
        panelDescription = description.transform.GetChild(1).GetComponent<Text>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        panelName.text = componentName;
        panelDescription.text = componentDescription;
    }
}
