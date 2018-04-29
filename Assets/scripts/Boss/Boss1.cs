using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

	public GameObject[] phases;

	private bool moveToCenter = false, moveToSide = false;

	Vector3 center = new Vector3 (0, 0, 0);
	Vector3 side = new Vector3 (8, 0, 0);

	void Start() {
		Invoke ("BossPhase1", 3);
		Event.StartListening (Event.GameEvent.BossHealth1, BossPhase2a);
	}

	void Update() {
		if (moveToCenter) {
			transform.position = Vector3.MoveTowards (transform.position, center, 5 * Time.deltaTime);
			if (transform.position == center) {
				moveToCenter = false;
				BossPhase2b ();
			}
		} else if (moveToSide) {
			transform.position = Vector3.MoveTowards (transform.position, side, 9 * Time.deltaTime);
			transform.rotation =  Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 8 );
			if (transform.position == side) {
				moveToSide = false;
				BossPhase3b ();
			}
		}
	}

	void BossPhase1() {
		phases [0].SetActive (false);
		phases [1].SetActive (true);
	}

	void BossPhase2a() {
		Event.StopListening (Event.GameEvent.BossHealth1, BossPhase2a);
		Event.StartListening (Event.GameEvent.BossHealth2, BossPhase3a);
		phases [1].SetActive (false);
		moveToCenter = true;
	}

	void BossPhase2b() {
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		phases [2].SetActive (true);
	}

	void BossPhase3a() {
		Event.StopListening (Event.GameEvent.BossHealth2, BossPhase3a);
		phases [2].SetActive (false);
		moveToSide = true;
	}
	
	void BossPhase3b() {
		phases [3].SetActive (true);
	}

}
