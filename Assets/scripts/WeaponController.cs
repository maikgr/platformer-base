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
			FireShots ();
		} else {
			InvokeRepeating ("Fire", initialDelay, fireRate);
		}
	}

	void FireShots() 
	{
	}

	void Fire ()
	{
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
	}
}
