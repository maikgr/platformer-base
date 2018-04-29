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
			result++;
		} else {
			cargo.Add (item, 1);
		}
	}

	public void AddCargoToWorkshopInventory() {
		Components.ItemName itemName;
		int val, result;

		foreach(KeyValuePair<Components.ItemName, int> entry in cargo)
		{
			itemName = entry.Key;
			val = entry.Value;

			if (workshopInventory.TryGetValue (itemName, out result)) {
				result += val;
			} else {
				workshopInventory.Add (itemName, val);
			}
		}
	}

	public void ClearCargo() {
		cargo = new Dictionary<Components.ItemName, int> ();
	}

	public IDictionary<Components.ItemName, int> GetInstalledComponents() {
		return installedComponents;
	}

}
