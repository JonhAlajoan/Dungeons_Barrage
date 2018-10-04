using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Transform muzzle;
	public Projectile projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;
	public float maxSpreadAngle;

	float nextShotTime;

	public void Shoot() {
		
		maxSpreadAngle = Random.Range (-20, 20);


		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;
			Projectile newProjectile = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;
			newProjectile.transform.Rotate(0,Random.Range(-20,maxSpreadAngle),0);
			newProjectile.SetSpeed (muzzleVelocity);

		}
	}
}