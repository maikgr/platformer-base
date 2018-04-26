using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	public bool isLeft;
	private Rigidbody rigidbody;
	private Transform transform;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
		transform = GetComponent<Transform> ();
		rigidbody.velocity = isLeft ? -transform.right * speed : transform.right * speed;
	}
}
