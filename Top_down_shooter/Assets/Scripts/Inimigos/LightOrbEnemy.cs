using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrbEnemy : LivingEntity {
	public GameObject shield;
	public Transform muzzle;
	public GameObject sfxControl;
	audioController sfxController;
	public GameObject hammer;
	protected override void Start () {
		base.Start ();
	}

}
