using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {
	
	private static bool created = false;

	private IDictionary<string, int> cargo = new Dictionary<string, int> ();
	private IDictionary<string, int> workshopInventory = new Dictionary<string, int> ();
	private IDictionary<string, int> installedComponents = new Dictionary<string, int> ();
		
	void Awake() {
		if (!created) {
			created = true;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void AddToCargo(string item) {
		int result;
		if (cargo.TryGetValue (item, out result)) {
			result++;
		} else {
			cargo.Add (item, 1);
		}
	}

	public void AddCargoToWorkshopInventory() {
		string itemName;
		int val, result;

		foreach(KeyValuePair<string, int> entry in cargo)
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
		cargo = new Dictionary<string, int> ();
	}



}
