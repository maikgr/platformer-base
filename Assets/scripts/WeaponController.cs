using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float initialDelay;
	public float pauseTime;
	public int numShots;


	void Start ()
	{
		if (numShots > 0) {
			StartCoroutine("FireShots");

		} else {
			InvokeRepeating ("Fire", initialDelay, fireRate);
		}
	}

	IEnumerator FireShots() 
	{
		while (true) {
			for (int i = 0; i < numShots; i++) {
				Fire ();
				yield return new WaitForSeconds (fireRate);
			}
			yield return new WaitForSeconds (pauseTime);
		}
	}

	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
	}
}
