using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerBaseStats {
	public float minBulletSpeed;
	public float baseBulletSpeed;

	public float minBulletSize;
	public float baseBulletSize;

	public int minBulletDamage;
	public int baseBulletDamage;

	public int minBulletSpread;
	public int baseBulletSpread;

	public float minFiringRate;
	public float baseFiringRate;

	public float minMovementSpeed;
	public float baseMovementSpeed;

	public int baseHealth;

	public int baseContactDamage;

}
	
public class Converter : MonoBehaviour {
	public PlayerBaseStats playerBaseStats;

	private IDictionary<Components.ItemName, int> installedComponents;

	private float bulletSpeed;
	private float bulletSize;
	private int bulletDamage;
	private float firingRate;
	private int pierce;
	private int spread;
	private int health;
	private float movementSpeed;
	private int contactDamge;

	private GameObject playerBullet;
	private PlayerController playerController;

	private delegate void CalcStats(int multiplier);

	private IDictionary<Components.ItemName, CalcStats> calcMap;

	// Use this for initialization
	void Start () {
		calcMap = new Dictionary<Components.ItemName, CalcStats> () {
			{Components.ItemName.BulletSpeed, new CalcStats(CalcBulletSpeed)},
			{Components.ItemName.BulletSize, new CalcStats(CalcBulletSize)},
			{Components.ItemName.BulletDamage, new CalcStats(CalcBulletDamage)},
			{Components.ItemName.FiringRate, new CalcStats(CalcFiringRate)},
			{Components.ItemName.Pierce, new CalcStats(CalcBulletPierce)},
			{Components.ItemName.Spread, new CalcStats(CalcBulletSpread)},
			{Components.ItemName.Health, new CalcStats(CalcHealth)},
			{Components.ItemName.MovementSpeed, new CalcStats(CalcMovementSpeed)},
			{Components.ItemName.DamageOnContact, new CalcStats(CalcContactDamage)}
		};

		playerController = GetComponent<PlayerController> ();
		playerBullet = playerController.shot;

		ClearStats ();
		installedComponents = GameObject.Find ("Inventory").GetComponent<Inventory> ().GetInstalledComponents();

		// For testing
//		installedComponents = new Dictionary<Components.ItemName, int> () {
//			{Components.ItemName.BulletSpeed, 0},
//			{Components.ItemName.BulletSize, 0},
//			{Components.ItemName.BulletDamage, 0},
//			{Components.ItemName.FiringRate, 6},
//			{Components.ItemName.Pierce, 0},
//			{Components.ItemName.Spread, 10},
//			{Components.ItemName.Health, 0},
//			{Components.ItemName.MovementSpeed, 0},
//			{Components.ItemName.DamageOnContact, 5}
//		};

		CalculateStats ();
		ApplyStats ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CalculateStats() {
		Components.ItemName name;
		int val;
		foreach (KeyValuePair<Components.ItemName, int> entry in installedComponents) {
			name = entry.Key;
			val = entry.Value;

			calcMap [name] (val);
		}
	}

	void ApplyStats() {
		SetBulletSpeed ();
		SetBulletSize ();
		SetBulletDamage ();
		SetFiringRate ();
		SetBulletPierce ();
		SetBulletSpread ();
		SetHealth ();
		SetMovementSpeed ();
		SetDamageOnContact ();
	}

	void ClearStats() {
		bulletSpeed = 0;
		bulletSize = 0;
		bulletDamage = 0;
		firingRate = 0;
		pierce = 0;
		spread = 0;
		health = 0;
		contactDamge = 0;
		movementSpeed = 0;
	}

	public void SetBulletSpeed() {
		Mover mover = playerBullet.GetComponent<Mover> ();
		mover.speed = Mathf.Max (playerBaseStats.minBulletSpeed, playerBaseStats.baseBulletSpeed + bulletSpeed);
	}

	public void	SetBulletSize () {
		float x = Mathf.Max (playerBaseStats.minBulletSize, playerBaseStats.baseBulletSize + bulletSize);
		float y = Mathf.Max (playerBaseStats.minBulletSize, playerBaseStats.baseBulletSize + bulletSize);
		playerBullet.transform.localScale = new Vector3 (x, y, 1);
	}

	public void	SetBulletDamage () {
		DealDamageOnContact damage = playerBullet.GetComponent<DealDamageOnContact> ();
		damage.damage = Mathf.Max (playerBaseStats.minBulletDamage, playerBaseStats.baseBulletDamage + bulletDamage);
	}

	public void	SetFiringRate () {
		playerController.setFireRate(Mathf.Max (playerBaseStats.minFiringRate, playerBaseStats.baseFiringRate + firingRate));
	}

	public void	SetBulletPierce () {
	}

	public void	SetBulletSpread () {
		Transform[] allSpawn = playerController.allShotSpawn;
		int newSpread = Mathf.Min(Mathf.Max(playerBaseStats.minBulletSpread, playerBaseStats.baseBulletSpread + spread), 10);
		Transform[] spawns = new Transform[newSpread];

		for (int i = 0; i < newSpread; i++) {
			spawns [i] = allSpawn [i];
		}

		playerController.setShotSpawn (spawns);
	}

	public void SetHealth() {
		Health h = GetComponent<Health> ();
		h.SetFullHealth (playerBaseStats.baseHealth + health);
	}

	public void SetMovementSpeed() {
		playerController.setMovementSpeed (playerBaseStats.baseMovementSpeed + movementSpeed);
	}

	public void SetDamageOnContact() {
		DealDamageOnContact damage = GetComponent<DealDamageOnContact> ();
		damage.damage = playerBaseStats.baseContactDamage + contactDamge;
	}

	private void CalcBulletSpeed(int multiplier) {
		bulletSpeed += 6 * multiplier;
		bulletSize -= 0.1f * multiplier;
	}

	private void CalcBulletSize(int multiplier) {
		bulletSize += (0.25f * multiplier);
		bulletSpeed -= 1 * multiplier;
	}

	private void CalcBulletDamage(int multiplier) {
		bulletDamage += 2 * multiplier;
		bulletSpeed -= 2 * multiplier;
	}

	private void CalcFiringRate(int multiplier) {
		firingRate -= (0.05f * multiplier);
		bulletDamage -= 1 * multiplier;
	}

	private void CalcBulletPierce(int multiplier) {
		pierce += 1 * multiplier;
		firingRate += 0.025f * multiplier;
	}

	private void CalcBulletSpread(int multiplier) {
		spread += 1 * multiplier;
		firingRate += 0.025f * multiplier;
	}

	private void CalcHealth(int multiplier) {
		health += 1 * multiplier;
	}

	private void CalcMovementSpeed(int multiplier) {
		movementSpeed += 2 * multiplier;
	}

	private void CalcContactDamage(int multiplier) {
		contactDamge += 1 * multiplier;
	}
}
