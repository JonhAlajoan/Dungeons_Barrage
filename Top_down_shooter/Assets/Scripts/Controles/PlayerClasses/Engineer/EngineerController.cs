using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
public class EngineerController :ClassesPlayer {
 
    public bool isDamageBuffed;
    bool flagStop;
    void Awake()
    {
        //Set the cursor to be invisible at runtime
        Cursor.visible = false;
    }


    protected override void Start()
    {
        base.Start();
    }

    public override void AttackRight()
    {
        throw new System.NotImplementedException();
    }

    public override void Attack()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            sfxController.PlaySFXSounds("shotgun");
            animaController.SetTrigger("attack");
            TrashMan.spawn("EngineerPreShoot", muzzle.transform.position, muzzle.transform.rotation);
            GameObject modifyPositionSpawn = TrashMan.spawn("Projectile_Engineer", muzzle.transform.position, muzzle.transform.rotation);
            GameObject modifyPositionSpawn2 = TrashMan.spawn("Projectile_Engineer", muzzle.transform.position, muzzle.transform.rotation);
            GameObject modifyPositionSpawn3 = TrashMan.spawn("Projectile_Engineer", muzzle.transform.position, muzzle.transform.rotation);
            GameObject modifyPositionSpawn4 = TrashMan.spawn("Projectile_Engineer", muzzle.transform.position, muzzle.transform.rotation);
       
            modifyPositionSpawn.transform.Rotate(0, -15, 0);
            modifyPositionSpawn2.transform.Rotate(0, -5, 0);
            modifyPositionSpawn3.transform.Rotate(0, 5, 0);
            modifyPositionSpawn4.transform.Rotate(0, 15, 0);

            if(isDamageBuffed == true)
            {
                buffDamage();
            }
            
        }
    }

    public void InstantiateDamageBuff()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            animaController.SetTrigger("callVortex");
            TrashMan.spawn("Totem_Dmg_Buff", specialMuzzle.transform.position, specialMuzzle.transform.rotation);
            WPower -= 1;
        }
    }

    public void InstantiateASBuff()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            animaController.SetTrigger("callVortex");
            TrashMan.spawn("Totem_AS_Buff", specialMuzzle.transform.position, specialMuzzle.transform.rotation);
            WPower -= 1;
        }
    }

    public void SpawnShield()
    {
        TrashMan.spawn("Shield_Engineer", specialMuzzle.transform.position, specialMuzzle.transform.rotation);
        WPower -= 1;
    }

    IEnumerator buffAttackSpeed()
    {
        if(msBetweenShots>400)
        {
            msBetweenShots -= 400;
            yield return new WaitForSeconds(2f);
            msBetweenShots += 400;
        }
        
    }

    public void buffDamage()
    {
        animaController.SetTrigger("attack");
        GameObject modifyPositionSpawn = TrashMan.spawn("Projectile_Engineer", muzzle.transform.position, muzzle.transform.rotation);
        GameObject modifyPositionSpawn2 = TrashMan.spawn("Projectile_Engineer", muzzle.transform.position, muzzle.transform.rotation);
        GameObject modifyPositionSpawn3 = TrashMan.spawn("Projectile_Engineer", muzzle.transform.position, muzzle.transform.rotation);
        GameObject modifyPositionSpawn4 = TrashMan.spawn("Projectile_Engineer", muzzle.transform.position, muzzle.transform.rotation);

        modifyPositionSpawn.transform.Rotate(0, -45, 0);
        modifyPositionSpawn2.transform.Rotate(0, -30, 0);
        modifyPositionSpawn3.transform.Rotate(0, 30, 0);
        modifyPositionSpawn4.transform.Rotate(0, 45, 0);

        isDamageBuffed = false;
    }

    public override void Special()
    {

        if (specialQuantity >= 1)
        {
            animaController.SetTrigger("callVortex");
            GameObject newVortex = TrashMan.spawn("Turret", specialMuzzle.transform.position, specialMuzzle.transform.rotation);
            specialQuantity -= 1;
        }
    }

    public override void Update()
    {
        base.Update();

        if(hasFoundAllReferences && flagStop == false)
        {
            isDamageBuffed = false;
            wPowerSub.text = "Mechanism:";
            flagStop = true;
        }
        textWPower.text = WPower.ToString("#0");
        if (Input.GetMouseButton(0))
        {
           
            if (WPower >=0)
            {
                Attack();
            }

        }

        if(Input.GetMouseButton(1))
        {
            if (WPower >= 1)
            {
                InstantiateDamageBuff();
                sfxController.PlaySFXSounds("bullet_arcane");
            }
        }

        if(Input.GetButtonDown("Fire2"))
        {
            if (WPower >=1)
            {
                InstantiateASBuff();
                sfxController.PlaySFXSounds("bullet_arcane");
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (WPower >= 1)
            {
                SpawnShield();
                sfxController.PlaySFXSounds("bullet_arcane");
            }
        }

    }
}
