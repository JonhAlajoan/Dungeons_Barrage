using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonballOrbe : LivingEntity {

	/* General explanation for the enemies scripting
	 *    - if it does have a rotacao (rotation) script, generally it is a iTween that rotates it 45 degrees each set of seconds
	 * 	  - the nextAttackTime is equal to the player's controller, just the miliseconds between each shot
	 *	  - Trashman not used because the quantity of cannonballs is very low
	 */
	int numRandom;
	public Transform muzzle;
	public projectileCannonBall projectile;
	projectileCannonBall projetilSpawn;
	public float msBetweenShots = 1000;
	public float nextShotTime = 2;
	float timeBetweenAttacks = 0.1f;
	float nextAttackTime;
	public float count=1;
	public GameObject cubo;
	public GameObject sfxCannonball;
	audioController ssfxCannonball;

// 	public audioController sfxCannonball;

	protected override void Start () {
		base.Start ();
		sfxCannonball = GameObject.FindWithTag ("audioSource");
		ssfxCannonball = sfxCannonball.GetComponent<audioController> ();
		StartCoroutine ("delay");

	}
	IEnumerator rotacao(){
		iTween.RotateBy (cubo, iTween.Hash (
			"y", 0.20f,
			"Time",4f	
		));
		yield return null;

	}

	void Update () {
		count += 1 * Time.deltaTime;
		if (Time.time > nextAttackTime) {
			StartCoroutine ("delayInicio");

			Attack ();
		}
		StartCoroutine ("rotacao");
	}
	IEnumerator delay(){
		yield return new WaitForSeconds (1f);
	}
	IEnumerator delayInicio(){
		yield return new WaitForSeconds (0.5f);
	}

	public void Attack() {
		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;

			TrashMan.spawn ("CannonBall", muzzle.transform.position, muzzle.transform.rotation);
			ssfxCannonball.PlaySFXSounds ("cannonball_explosion");


		}
	}
		
}
