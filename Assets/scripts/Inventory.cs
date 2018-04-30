using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {
	
	private static bool created = false;

	private IDictionary<Components.ItemName, int> cargo = new Dictionary<Components.ItemName, int> ();
	private IDictionary<Components.ItemName, int> workshopInventory = new Dictionary<Components.ItemName, int> ();
	private IDictionary<Components.ItemName, int> installedComponents = new Dictionary<Components.ItemName, int> ();
		
	void Awake() {
		if (!created) {
			created = true;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void AddToCargo(Components.ItemName item) {
		int result;
		if (cargo.TryGetValue (item, out result)) {
            cargo[item] = ++result;
		} else {
			cargo.Add (item, 1);
		}
	}

	public void AddCargoToWorkshopInventory() {
		foreach(KeyValuePair<Components.ItemName, int> entry in cargo) {
            AddToWorkshopInventory(entry.Key, entry.Value);
        }
	}

	public void ClearCargo() {
		cargo = new Dictionary<Components.ItemName, int> ();
	}

    public void InstallComponent(Components.ItemName item) {
        int quantity;
        if(installedComponents.TryGetValue(item, out quantity)) {
            installedComponents[item]++;
        } else {
            installedComponents.Add(item, 1);
        }
        RemoveFromWorkshopInventory(item, 1);
    }

    public void UninstallComponent(Components.ItemName item) {
        if (installedComponents[item] > 1) {
            installedComponents[item]--;
        } else {
            installedComponents.Remove(item);
        }
        AddToWorkshopInventory(item, 1);
    }

    public void AddToWorkshopInventory(Components.ItemName item, int quantity) {
        int result;
        if (workshopInventory.TryGetValue(item, out result)) {
            result += quantity;
        } else {
            workshopInventory.Add(item, quantity);
        }
    }

    public void RemoveFromWorkshopInventory(Components.ItemName item, int quantity) {
        if(workshopInventory[item] > 1) {
            workshopInventory[item] -= quantity;
        } else {
            workshopInventory.Remove(item);
        }
    }

    public IDictionary<Components.ItemName, int> GetInstalledComponents() {
        return installedComponents;
    }

    public IDictionary<Components.ItemName, int> GetWorkshopInventory() {
        return workshopInventory;
    }
}
