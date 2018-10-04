using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireOrbEnemy : LivingEntity {

	public Transform muzzle;
	public Transform muzzle2;

	public ProjectileFire projectile;

	float speed;
	public float msBetweenShots = 100;
	public float nextShotTime;
	float timeBetweenAttacks = 0.1f;
	float nextAttackTime;

	protected override void Start () {
		base.Start ();
	}


	void Update () {		
		if (Time.time > nextAttackTime) {
			Attack ();
		}
	}


	public void Attack() {

		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;
			ProjectileFire newProjectile = Instantiate (projectile, muzzle.position, muzzle.rotation) as ProjectileFire;
			ProjectileFire newProjectil2 = Instantiate (projectile, muzzle2.position, muzzle2.rotation) as ProjectileFire;


			newProjectile.transform.Rotate (0, 0, 0);
		}
	}
}
