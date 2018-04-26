using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetKey("space") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate ()
	{
		rb = GetComponent<Rigidbody> ();

		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (hAxis, vAxis, 0.0f);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);
	}
}