using UnityEngine;
using System.Collections;

public class AimedMover : MonoBehaviour
{
	public float speed;

	private Transform target;
	private Vector3 direction;
	private Rigidbody rigidbody;
	private Transform transform;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
		transform = GetComponent<Transform> ();
		target = GameObject.FindWithTag ("Player").transform;

		direction =	target.position - transform.position;
	}

	void Update () 
	{
		transform.position += direction * speed * Time.deltaTime;
	}

}
