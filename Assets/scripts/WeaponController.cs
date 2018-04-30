using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
	public string name; // Name of weapon

	public GameObject shot;
	public Transform[] shotSpawn;

	public float initialDelay; // initial delay 
	public float fireRate; // rate at which bullets are fired
	public float weaponDelay; // delay between each spawn point (if multiple)
	public float pauseTime; // time to next barrage
	public int numShots; // number of shots before pausing

    private AudioSource shootSfx;

	void Start ()
	{
		StartCoroutine("FireShots");
        shootSfx = GetComponent<AudioSource>();
	}

	IEnumerator FireShots() 
	{
		yield return new WaitForSeconds (initialDelay);
		while (true) {
			for (int i = 0; i < numShots; i++) {
				StartCoroutine("Fire");
				yield return new WaitForSeconds (fireRate);
			}
			yield return new WaitForSeconds (pauseTime);
		}
	}

	IEnumerator Fire ()
	{
        if (shootSfx != null) {
            shootSfx.Play();
        }
		for (int i = 0; i < shotSpawn.Length; i++) {
			Instantiate (shot, shotSpawn[i].position, shotSpawn[i].rotation);
			yield return new WaitForSeconds (weaponDelay);
		}
	}
}
