using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public enum SpawnState
	{
		SPAWNING, WAITING, COUNTING 
	};

	public float[] timeToNextWave;
	public GameObject[] enemyWave; //prefabs

	private int currentWave = 0;
	private float timeCountdown;

	private SpawnState state = SpawnState.COUNTING;

	// Use this for initialization
	void Start () {
		timeCountdown = timeToNextWave[currentWave];
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

		Instantiate(enemy, new Vector3(16, 0, 0), Quaternion.identity);

		state = SpawnState.WAITING;
		yield break;
	}
}
