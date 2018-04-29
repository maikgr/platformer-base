using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {
	
	private static bool created = false;

	private IDictionary<string, int> temp = new Dictionary<string, int> ();
	private IDictionary<string, int> inventory = new Dictionary<string, int> ();
	private IDictionary<string, int> workshop = new Dictionary<string, int> ();
		
	void Awake() {
		if (!created) {
			created = true;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void AddToTemp(string item) {
		int result;
		if (temp.TryGetValue (item, out result)) {
			result++;
		} else {
			temp.Add (item, 1);
		}
	}

	public void AddTempToInventory() {
		string itemName;
		int val, result;

		foreach(KeyValuePair<string, int> entry in temp)
		{
			itemName = entry.Key;
			val = entry.Value;

			if (inventory.TryGetValue (itemName, out result)) {
				result += val;
			} else {
				inventory.Add (itemName, val);
			}
		}
	}

	public void ClearTemp() {
		temp = new Dictionary<string, int> ();
	}



}
