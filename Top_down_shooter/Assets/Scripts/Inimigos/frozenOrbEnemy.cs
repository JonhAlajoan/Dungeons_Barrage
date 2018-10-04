using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frozenOrbEnemy : LivingEntity {

	public Transform muzzle;
    public float msBetweenShots = 100;
	public float nextShotTime;
	float timeBetweenAttacks = 0.1f;
	float nextAttackTime;
	public float count=1;
	public ProjectileFrozen ProjectileFrozen;
	GameObject sfxController;
	audioController auxSfxController;

	protected override void Start () {
		base.Start ();
		sfxController = GameObject.FindWithTag ("audioSource");
		auxSfxController = sfxController.GetComponent<audioController> ();
	}

	void Update () {
		count += 1 * Time.deltaTime;
		if (Time.time > nextAttackTime) {
			Attack ();
		}
	}

	public void Attack() {
		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;
			auxSfxController.PlaySFXSounds ("Frozen_Projectile");
			TrashMan.spawn ("Projetil_Frozen_Orbe", muzzle.transform.position, muzzle.transform.rotation);
        }
	}

}
