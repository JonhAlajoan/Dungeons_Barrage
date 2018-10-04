using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class inimigoTorre : LivingEntity {
	public enum State {Idle, Charging, Attacking};
	State currentState;

	public Transform inimigo;
	public Transform muzzle;
	public Projectile_enemy projectile;
	public Transform target;
	LivingEntity targetEntity;
	float speed;
	public float msBetweenShots = 100;
	public float nextShotTime;
	float attackDistanceThreshold = 40.0f;
	float timeBetweenAttacks = 0.1f;
	int numScore;
	public Text Score;
	float nextAttackTime;
	float myCollisionRadius;
	float targetCollisionRadius;
	bool hasTarget;
	GameObject sfxController;
	audioController auxSfxController;
	protected override void Start () {

		base.Start ();

		sfxController = GameObject.FindWithTag ("audioSource");
		auxSfxController = sfxController.GetComponent<audioController> ();
		try{
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				hasTarget = true;
				inimigo = GetComponent<Transform> ();
				target = GameObject.FindGameObjectWithTag ("Player").transform;
			}
		}

		catch(NullReferenceException){

		}
	}

	void OnTargetDeath(){
		numScore = numScore + 10;
		Score.text = numScore.ToString ();
	}

	void Update () {
		if (hasTarget == true) {
            if (Time.time > nextAttackTime)
            {
                float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
                if (sqrDstToTarget < Mathf.Pow(attackDistanceThreshold + targetCollisionRadius, 2))
                {
                    nextAttackTime = Time.time + timeBetweenAttacks;
                    auxSfxController.PlaySFXSounds("Lotus_Projectile");
                    Attack();
                }
            }
		}
		
	}

	public void Attack() {

		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;
			TrashMan.spawn("ProjectileWind",muzzle.transform.position,muzzle.transform.rotation);
			transform.LookAt (target);
			transform.Rotate (0, UnityEngine.Random.Range (-4f, 4f), 0);
		}

	}

}

