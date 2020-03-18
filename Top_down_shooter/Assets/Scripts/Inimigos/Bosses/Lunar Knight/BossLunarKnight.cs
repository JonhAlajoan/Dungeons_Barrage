using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BossLunarKnight : LivingEntity {

	public enum State { phase1, phase2, phase3, phase4 };
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

	// Use this for initialization
	protected override void Start ()
	{

		base.Start();
		currentState = State.phase1;
		sfxController = GameObject.FindWithTag("audioSource");
		auxSfxController = sfxController.GetComponent<audioController>();
		
	}

	void OnTargetDeath()
	{
		numScore = numScore + 10;
		Score.text = numScore.ToString();
	}

	void Update()
	{
		if(currentState == State.phase1)
		{

		}
	}

	public void Attack()
	{

		if (Time.time > nextShotTime)
		{
			nextShotTime = Time.time + msBetweenShots / 1000;
			TrashMan.spawn("ProjectileWind", muzzle.transform.position, muzzle.transform.rotation);
			transform.LookAt(target);
			transform.Rotate(0, UnityEngine.Random.Range(-4f, 4f), 0);
		}

	}
}
