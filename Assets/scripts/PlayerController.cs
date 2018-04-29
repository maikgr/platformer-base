using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{

	public Transform[] allShotSpawn;
	public Boundary boundary;

    private Rigidbody rb;

    private float speed;

    public GameObject shot;
    private Transform[] shotSpawn;

    private float fireRate;
    private float nextFire;
    private AudioSource shootSfx;

    private void Start()
    {
        shootSfx = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            shootSfx.Play();
            for (int i = 0; i < shotSpawn.Length; i++) {
                Instantiate(shot, shotSpawn[i].position, shotSpawn[i].rotation);
            }
        }
    }

    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, vAxis, 0.0f);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
    }

	public void setFireRate(float rate) {
		fireRate = rate;
	}

	public void setMovementSpeed(float s) {
		speed = s;
	}

	public void setShotSpawn(Transform[] spawns) {
		shotSpawn = spawns;
	}
}