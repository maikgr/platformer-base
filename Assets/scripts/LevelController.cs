using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public enum SpawnState
	{
		SPAWNING, WAITING, COUNTING 
	};

    public Vector2 spawnPoint;
	public float[] timeToNextWave;
	public GameObject[] enemyWave; //prefabs

	private int currentWave = 0;
	private float timeCountdown;

	private SpawnState state = SpawnState.COUNTING;

	// Use this for initialization
	void Start () {
		timeCountdown = timeToNextWave[currentWave];
		Event.StartListening (Event.GameEvent.BossDead, OnBossDie);
		Event.StartListening (Event.GameEvent.PlayerDead, OnPlayerDie);

	}
	
	// Update is called once per frame
	void Update () {
		if (timeCountdown <= 0) {
			if (state != SpawnState.SPAWNING) {
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
		Debug.Log ("Boss dead");
	}

	void OnPlayerDie() {
		Debug.Log ("Player dead");
	}
}
