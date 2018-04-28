using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	public string direction;
	private Rigidbody rigidbody;
	private Transform transform;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();

		Vector3 dir;

		if (direction == "left") {
			dir = new Vector3 (-1, 0, 0);
		} else if (direction == "right") {
			dir = new Vector3 (1, 0, 0);
		} else if (direction == "up") {
			dir = new Vector3 (0, 1, 0);
		} else {
			dir = new Vector3 (0, -1, 0);
		}

		rigidbody.velocity = dir * speed;
	}
}
