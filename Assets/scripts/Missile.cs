using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
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
			}

	void Update () 
	{
		direction =	target.position - transform.position;
		transform.position += direction * speed * Time.deltaTime;
	}

}
