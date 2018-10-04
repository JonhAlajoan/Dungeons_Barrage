using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vortexIsa : MonoBehaviour {

    public Transform muzzle;
    public float msBetweenShots = 100;
    public float nextShotTime;
    float timeBetweenAttacks = 0.1f;
    float nextAttackTime;
    public float count = 1;

    GameObject sfxController;
    audioController auxSfxController;
    // Use this for initialization
    void Start () {
        sfxController = GameObject.FindWithTag("audioSource");
        auxSfxController = sfxController.GetComponent<audioController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextAttackTime)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            auxSfxController.PlaySFXSounds("Frozen_Projectile");
            GameObject projectile = TrashMan.spawn("Projectile_Isa", muzzle.transform.position, muzzle.transform.rotation);
            //projectile.transform.Rotate(0, 90, 0);
        }
    }

}
