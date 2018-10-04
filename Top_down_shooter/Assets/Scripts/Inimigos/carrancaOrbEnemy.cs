using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrancaOrbEnemy : LivingEntity {

	public Transform muzzle;
    public Transform muzzle2;
    public Transform muzzle3;
    public projectile_Carranca projectile;
	projectile_Carranca projetilSpawn;
	float speed;
	float speedUpdt;
	public float msBetweenShots = 100;
	public float nextShotTime;
	float timeBetweenAttacks = 0.1f;
	float nextAttackTime;
	public float count=1;
	public GameObject cubo;
	int numRandom;
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
        if (count >= 3)
        {
            iTween.RotateBy(cubo, iTween.Hash(
            "y", 0.20f,
            "Time", 1f
            ));
            count = 0;
        }
	}

	public void Attack() {

		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;
			auxSfxController.PlaySFXSounds ("Carranca_Projectile");
			TrashMan.spawn ("Projétil_Carranca", muzzle.transform.position, muzzle.transform.rotation);
            TrashMan.spawn("Projétil_Carranca", muzzle2.transform.position, muzzle2.transform.rotation);
            TrashMan.spawn("Projétil_Carranca", muzzle3.transform.position, muzzle3.transform.rotation);
        }
	}

}
