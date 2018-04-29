using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components {

	public static string BulletSpeed = "BulletSpeed",
		BulletSize = "BulletSize",
		BulletDamage = "BulletDamage",
		FiringRate = "FiringRate",
		Pierce = "Pierce",
		Spread = "Spread",
		Explosion = "Explosion",
		Homing = "Homing",
		Health = "HealthAmount",
		MovementSpeed = "MovementSpeed",
		DamageOnContact = "DamageOnContact";

	public enum ItemName {
		BulletSpeed,
		BulletSize,
		BulletDamage,
		FiringRate,
		Pierce,
		Spread,
		Explosion,
		Homing,
		Health,
		MovementSpeed,
		DamageOnContact
	};

	public static IDictionary<ItemName, string> enumToString = new Dictionary<ItemName, string>() {
		{ItemName.BulletSpeed, BulletSpeed},
		{ItemName.BulletSize, BulletSize},
		{ItemName.BulletDamage, BulletDamage},
		{ItemName.FiringRate, FiringRate},
		{ItemName.Pierce, Pierce},
		{ItemName.Spread, Spread},
		{ItemName.Explosion, Explosion},
		{ItemName.Homing, Homing},
		{ItemName.Health, Health},
		{ItemName.MovementSpeed, MovementSpeed},
		{ItemName.DamageOnContact, DamageOnContact}
	};
}
