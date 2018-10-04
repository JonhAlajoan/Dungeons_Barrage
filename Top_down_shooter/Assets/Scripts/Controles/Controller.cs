using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class Controller : ClassesPlayer {
     
	
	public Transform muzzle2;
	public Transform muzzle45;
	public Transform muzzle45Neg;
	public Transform orbe;
	public Transform orbe2;
	public Transform orbeMuzzle;
	public Transform orbe2Muzzle;

	public Transform bombMuzzle;

    bool stopFlag;

	void Awake()
	{
		
		Cursor.visible = false;
	}


	protected override void Start()
    {
		
		base.Start ();
        stopFlag = false;


    }

    public override void AttackRight()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        animaController.SetBool("Attack", true);
        Vector3 newPosMuzzle = new Vector3(Mathf.Lerp(orbe.transform.position.x, muzzle.transform.position.x, 3), Mathf.Lerp(orbe.transform.position.y, muzzle.transform.position.y, 3), Mathf.Lerp(orbe.transform.position.z, muzzle.transform.position.z, 3));
        Vector3 newPosMuzzle2 = new Vector3(Mathf.Lerp(orbe2.transform.position.x, muzzle2.transform.position.x, 3), Mathf.Lerp(orbe2.transform.position.y, muzzle2.transform.position.y, 3), Mathf.Lerp(orbe2.transform.position.z, muzzle2.transform.position.z, 3));
        orbe.transform.position = newPosMuzzle;
        orbe2.transform.position = newPosMuzzle2;

        if (WPower <= 15)
        {
            Shoot();

        }
        if (WPower >= 15 && WPower <= 40)
        {
            shootLevel2();

        }
        if(WPower>=40)
        {
            shootLevel3();
        }
           
    }

    public void Shoot()
    {
		if (Time.time > nextShotTime)
        {
			nextShotTime = Time.time + msBetweenShots / 1000;
            sfxController.PlaySFXSounds("ArcaneMissiles");
            TrashMan.spawn ("particula_projetil_final", muzzle.transform.position, muzzle.transform.rotation);
			TrashMan.spawn ("particula_projetil_final", muzzle2.transform.position, muzzle2.transform.rotation);
		}
	}

	public void shootLevel2(){
		
			if (Time.time > nextShotTime) {
				nextShotTime = Time.time + msBetweenShots / 1000;
            sfxController.PlaySFXSounds("ArcaneMissiles");
            TrashMan.spawn ("projetil_level_2", muzzle.transform.position, muzzle.transform.rotation);
				TrashMan.spawn ("projetil_level_2", muzzle2.transform.position, muzzle2.transform.rotation);



				TrashMan.spawn ("projetil_level_2_Mini", muzzle.transform.position, muzzle45.transform.rotation);

				TrashMan.spawn ("projetil_level_2_Mini", muzzle2.transform.position,muzzle45Neg.transform.rotation);

			}
	}

	public void shootLevel3(){
			if (Time.time > nextShotTime) {
				nextShotTime = Time.time + msBetweenShots / 1000;
				int randomNum = Random.Range (0, 15);
            sfxController.PlaySFXSounds("ArcaneMissiles");
            TrashMan.spawn ("projetil_level_2", muzzle.transform.position, muzzle.transform.rotation);
				TrashMan.spawn ("projetil_level_2", muzzle2.transform.position, muzzle2.transform.rotation);
				TrashMan.spawn ("projetil_level_2_Mini", muzzle.transform.position, muzzle45.transform.rotation);
				TrashMan.spawn ("projetil_level_2_Mini", muzzle2.transform.position,muzzle45Neg.transform.rotation);
				if (randomNum == 14) {
					int random = Random.Range (0, 2);
					if (random == 1) {
						TrashMan.spawn ("projectile_level_3", muzzle.transform.position, muzzle.transform.rotation);
					} else {
						TrashMan.spawn ("projectile_level_3", muzzle2.transform.position, muzzle2.transform.rotation);
					}
				}
			}
	}

	public override void Special()
    {
		
		if (specialQuantity>=1)
        {
            TrashMan.spawn("Black_Hole", gameObject.transform.position,specialMuzzle.rotation);
			sfxController.PlaySFXSounds ("vortex");
			specialQuantity -= 1;
		}
	}


	public override void Update () 
    {
        base.Update();
        textWPower.text = WPower.ToString("#0");
        if(hasFoundAllReferences && stopFlag == false)
        {
            postProcessing.depthOfField.enabled = false;
            stopFlag = true;
        }
	

		if (Input.GetButton ("Fire1")) {

            Attack();

		} else {
			animaController.SetBool ("Attack", false);

			orbe.transform.position = orbeMuzzle.transform.position;
			orbe2.transform.position = orbe2Muzzle.transform.position;
		}

	}
}
