using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
public class AlchemistController : ClassesPlayer
{

    bool allowTogglePower = true;
    public Transform muzzle2;

    public Transform bombMuzzle;

    int flag = 0;
    public bool isDamageBuffed;

    public bool machineGunEnabled;
    bool gasEnabled;
    bool thunderEnabled;
    bool lifeEnabled;
    bool airEnabled;

    bool stopFlag;


    void Awake()
    {
        Cursor.visible = false;
    }


    protected override void Start()
    {
        base.Start();
        stopFlag = false;
       
    }


    public void ShootLevel1()
    {
        if (Time.time > nextShotTime)
        {
            sfxController.PlaySFXSounds("AlchemistFire");
            nextShotTime = Time.time + msBetweenShots / 1000;
            animaController.SetTrigger("attack");
            TrashMan.spawn("AlchemistPreShoot", muzzle.transform.position, muzzle.transform.rotation);
            TrashMan.spawn("ProjectileAlchemist", muzzle.transform.position, muzzle.transform.rotation);

            if(isDamageBuffed == true)
            {
                sfxController.PlaySFXSounds("AlchemistFire");
                GameObject modifyPositionSpawn = TrashMan.spawn("ProjectileAlchemist", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn2 = TrashMan.spawn("ProjectileAlchemist", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn3 = TrashMan.spawn("ProjectileAlchemist", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn4 = TrashMan.spawn("ProjectileAlchemist", muzzle.transform.position, muzzle.transform.rotation);

                modifyPositionSpawn.transform.Rotate(0, -15, 0);
                modifyPositionSpawn2.transform.Rotate(0, -5, 0);
                modifyPositionSpawn3.transform.Rotate(0, 5, 0);
                modifyPositionSpawn4.transform.Rotate(0, 15, 0);
            }
        }
    }

    public void ShootMachineGun()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            sfxController.PlaySFXSounds("MachineGun");
            animaController.SetTrigger("attack");
            GameObject preShoot = TrashMan.spawn("AlchemistMachineGunPreShoot", muzzle.transform.position, muzzle.transform.rotation);
            TrashMan.spawn("Projectile_Machine_Gun", muzzle.transform.position, muzzle.transform.rotation);
            preShoot.transform.parent = muzzle;
            if (isDamageBuffed == true)
            {
                machineGunBuffed();
            }
        }
    }

    public void shootGas()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            sfxController.PlaySFXSounds("AlchemistFire");
            animaController.SetTrigger("attack");
            GameObject preShoot = TrashMan.spawn("AlchemistGasPreShoot", muzzle.transform.position, muzzle.transform.rotation);
            TrashMan.spawn("ProjectileGas", muzzle.transform.position, muzzle.transform.rotation);
            preShoot.transform.parent = muzzle;

            if (isDamageBuffed == true)
            {
                sfxController.PlaySFXSounds("AlchemistFire");
                GameObject modifyPositionSpawn = TrashMan.spawn("ProjectileGas", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn2 = TrashMan.spawn("ProjectileGas", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn3 = TrashMan.spawn("ProjectileGas", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn4 = TrashMan.spawn("ProjectileGas", muzzle.transform.position, muzzle.transform.rotation);

                modifyPositionSpawn.transform.Rotate(0, -15, 0);
                modifyPositionSpawn2.transform.Rotate(0, -5, 0);
                modifyPositionSpawn3.transform.Rotate(0, 5, 0);
                modifyPositionSpawn4.transform.Rotate(0, 15, 0);
            }
        }
    }

    public void shootThunder()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            sfxController.PlaySFXSounds("AlchemistFire");
            animaController.SetTrigger("attack");
            GameObject preShoot = TrashMan.spawn("AlchemistThunderPreShoot", muzzle.transform.position, muzzle.transform.rotation);
            TrashMan.spawn("Projectile_Thunder", muzzle.transform.position, muzzle.transform.rotation);
            preShoot.transform.parent = muzzle;

            if (isDamageBuffed == true)
            {
                GameObject modifyPositionSpawn = TrashMan.spawn("Projectile_Thunder", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn2 = TrashMan.spawn("Projectile_Thunder", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn3 = TrashMan.spawn("Projectile_Thunder", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn4 = TrashMan.spawn("Projectile_Thunder", muzzle.transform.position, muzzle.transform.rotation);

                modifyPositionSpawn.transform.Rotate(0, -15, 0);
                modifyPositionSpawn2.transform.Rotate(0, -5, 0);
                modifyPositionSpawn3.transform.Rotate(0, 5, 0);
                modifyPositionSpawn4.transform.Rotate(0, 15, 0);
            }
        }
    }

    public void shootLife()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            sfxController.PlaySFXSounds("MachineGun");
            animaController.SetTrigger("attack");
            GameObject preShoot = TrashMan.spawn("AlchemistLifePreShoot", muzzle.transform.position, muzzle.transform.rotation);
            TrashMan.spawn("Projectile_Life", muzzle.transform.position, muzzle.transform.rotation);
            preShoot.transform.parent = muzzle;

            if (isDamageBuffed == true)
            {
                GameObject modifyPositionSpawn = TrashMan.spawn("Projectile_Life", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn2 = TrashMan.spawn("Projectile_Life", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn3 = TrashMan.spawn("Projectile_Life", muzzle.transform.position, muzzle.transform.rotation);
                GameObject modifyPositionSpawn4 = TrashMan.spawn("Projectile_Life", muzzle.transform.position, muzzle.transform.rotation);

                modifyPositionSpawn.transform.Rotate(0, -15, 0);
                modifyPositionSpawn2.transform.Rotate(0, -5, 0);
                modifyPositionSpawn3.transform.Rotate(0, 5, 0);
                modifyPositionSpawn4.transform.Rotate(0, 15, 0);
            }
        }
    }

   
    public void machineGunBuffed()
    {
        GameObject modifyPositionSpawn = TrashMan.spawn("Projectile_Machine_Gun", muzzle.transform.position, muzzle.transform.rotation);
        GameObject modifyPositionSpawn2 = TrashMan.spawn("Projectile_Machine_Gun", muzzle.transform.position, muzzle.transform.rotation);
        GameObject modifyPositionSpawn3 = TrashMan.spawn("Projectile_Machine_Gun", muzzle.transform.position, muzzle.transform.rotation);
        GameObject modifyPositionSpawn4 = TrashMan.spawn("Projectile_Machine_Gun", muzzle.transform.position, muzzle.transform.rotation);

        modifyPositionSpawn.transform.Rotate(0, -15, 0);
        modifyPositionSpawn2.transform.Rotate(0, -5, 0);
        modifyPositionSpawn3.transform.Rotate(0, 5, 0);
        modifyPositionSpawn4.transform.Rotate(0, 15, 0);
    }

    IEnumerator buffAttackSpeed()
    {
            msBetweenShots = 100;
            machineGunEnabled = true;

            gasEnabled = false;
            airEnabled = false;
            thunderEnabled = false;
            lifeEnabled = false;
            
            yield return new WaitForSeconds(10f);
            msBetweenShots = 800;
            machineGunEnabled = false;
    }

    IEnumerator buffGas()
    {
            msBetweenShots = 500;
            gasEnabled = true;

            machineGunEnabled = false;
            airEnabled = false;
            thunderEnabled = false;
            lifeEnabled = false;

            yield return new WaitForSeconds(10f);
            gasEnabled = false;
            msBetweenShots = 800;
    }

    IEnumerator buffThunder()
    {
        speed = 35;
            thunderEnabled = true;

            gasEnabled = false;
            airEnabled = false;            
            lifeEnabled = false;
            machineGunEnabled = false;

            yield return new WaitForSeconds(10f);
            thunderEnabled = false;
            speed = 30;
    }

    IEnumerator buffLife()
    {
            msBetweenShots = 300;


            lifeEnabled = true;

            gasEnabled = false;
            airEnabled = false;
            thunderEnabled = false;
            machineGunEnabled = false;

            yield return new WaitForSeconds(10f);
            lifeEnabled = false;

            msBetweenShots = 800;
        
    }

    IEnumerator disableBuff()
    {
        yield return new WaitForSeconds(6f);
        isDamageBuffed = false;
    }

    //The bomb function instantiates a new vortex at the direction that the player is facing and triggers the animation
    public override void Special()
    {

        if (specialQuantity >= 1)
        {
            isDamageBuffed = true;
            animaController.SetTrigger("callVortex");
            StartCoroutine("disableBuff");
            specialQuantity -= 1;
        }
    }

    public override void Attack()
    {
        if (machineGunEnabled == true)
        {
            ShootMachineGun();
            wPowerSub.text = "Gun: Machine";
        }

        if (gasEnabled == true)
        {

            shootGas();
            wPowerSub.text = "Gun: Gas";
        }

        if (thunderEnabled == true)
        {

            shootThunder();
            wPowerSub.text = "Gun: Thunder";
        }

        if (lifeEnabled == true)
        {
            shootLife();
            wPowerSub.text = "Gun: Life";
        }

        if (machineGunEnabled == false && gasEnabled == false && airEnabled == false && thunderEnabled == false && lifeEnabled == false)
        {
            ShootLevel1();
            wPowerSub.text = "Gun: Rebound";
        }
    }

    public override void AttackRight()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        
        base.Update();

        if (hasFoundAllReferences && stopFlag == false)
        {
            machineGunEnabled = false;

            isDamageBuffed = false;

            canvasPause.SetActive(false);

            wPowerSub = GameObject.FindGameObjectWithTag("textWpowerSub").GetComponent<Text>();
            textWPower.text = "";
            stopFlag = true;
        }


        if (Input.GetMouseButton(0))
        {
            Attack();
        }

        
   }
}
