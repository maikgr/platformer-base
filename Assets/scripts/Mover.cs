using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public Transform target;
	public float speed;
	private Rigidbody rigidbody;

	void Start ()
	{
		if (target != null) {
			rigidbody = target.GetComponent<Rigidbody> ();
		} else {
			rigidbody = GetComponent<Rigidbody> ();
		}

		Vector3 dir = transform.right;
		dir.Normalize ();

		rigidbody.velocity = dir * speed;
	}
}
