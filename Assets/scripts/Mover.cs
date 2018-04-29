using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public Transform target;
	public float speed;
    public MoveDirection direction;
	private Rigidbody rigidbody;

	void Start ()
	{
		if (target != null) {
			rigidbody = target.GetComponent<Rigidbody> ();
		} else {
			rigidbody = GetComponent<Rigidbody> ();
		}

		Vector3 dir = direction.Equals(MoveDirection.Right) ? transform.right : -transform.right;
		dir.Normalize ();

		rigidbody.velocity = dir * speed;
	}

    public enum MoveDirection {
        Left,
        Right
    }
}
