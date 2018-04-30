using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public enum SpawnState
	{
		SPAWNING, WAITING, COUNTING 
	};

    public Vector2 spawnPoint;
	public float[] timeToNextWave;
	public GameObject[] enemyWave; //prefabs
	private Inventory inventory;

	private int currentWave = 0;
	private float timeCountdown;

	public GameObject winText, loseText;

	private SpawnState state = SpawnState.COUNTING;

	// Use this for initializations
	void Start () {
		inventory = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		timeCountdown = timeToNextWave[currentWave];
		Event.StartListening (Event.GameEvent.BossDead, OnBossDie);
		Event.StartListening (Event.GameEvent.PlayerDead, OnPlayerDie);
	}
	
	// Update is called once per frame
	void Update () {
		if (timeCountdown <= 0 && currentWave < enemyWave.Length) {
			if (state != SpawnState.SPAWNING ) {
				StartCoroutine(SpawnWave(enemyWave[currentWave]));
			}
			currentWave++;
			timeCountdown = timeToNextWave[currentWave];
		} else {
			timeCountdown -= Time.deltaTime;
		}
	}

	IEnumerator SpawnWave(GameObject enemy) {
		state = SpawnState.SPAWNING;

		Instantiate(enemy, spawnPoint, Quaternion.identity);

		state = SpawnState.WAITING;
		yield break;
	}

	void OnBossDie() {
		inventory.AddCargoToWorkshopInventory ();
		inventory.ClearCargo ();
		winText.SetActive (true);
		Invoke ("LoadScene", 2);
		Debug.Log ("Boss dead");
	}

	void OnPlayerDie() {
		inventory.AddCargoToWorkshopInventory ();
		inventory.ClearCargo ();
		loseText.SetActive (true);
		Invoke ("LoadScene", 2);
		Debug.Log ("Player dead");
	}

	void LoadScene() {
		SceneManager.LoadScene ("mission", LoadSceneMode.Single);
	}
}
