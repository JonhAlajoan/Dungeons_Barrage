using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using System;

public class PriestController : ClassesPlayer
{



    bool allowTogglePower = true;
  

    public Transform bomb;
    public Transform bombMuzzle;
    public Transform healingMuzzle;
    public GameObject[] Enemies;

    Vector3 SpawnAcima;

    bool flagStart;

    void Awake()
    {
        Cursor.visible = false;
    }


    protected override void Start()
    {
       
        base.Start();
        
    }

    public override void Attack()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            animaController.SetTrigger("attack");
            GameObject modifyPositionSpawn = TrashMan.spawn("Shoot_Priest", muzzle.transform.position, muzzle.transform.rotation);
            modifyPositionSpawn.transform.parent = muzzle;

        }
    }

  

    public override void AttackRight()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            animaController.SetTrigger("callHealing");
            GameObject healtotem = TrashMan.spawn("HealingPriest", healingMuzzle.transform.position, healingMuzzle.transform.rotation);
            healtotem.transform.parent = healingMuzzle;
            WPower -= 1;
        }
    }

  
    public override void Special()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;

            if (specialQuantity >= 1)
            {
                animaController.SetTrigger("callVortex");
                Enemies = GameObject.FindGameObjectsWithTag("enemyWind");
                
                for (int i =0;i<Enemies.Length; i++)
                {
                    
                    Vector3 sumSpawnPositions = SpawnAcima + Enemies[i].transform.position;
                    GameObject newVortex = TrashMan.spawn("VortexPriest", sumSpawnPositions, bombMuzzle.transform.rotation);
                }
               specialQuantity -= 1;
            }

            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i] = null;
            }          
        }
    }

    
  
    public override void Update()
    {

        base.Update();

        if (hasFoundAllReferences && flagStart == false)
        {
            textWPower.text = WPower.ToString("#0");
          
            
            canvasPause.SetActive(false);
            SpawnAcima = new Vector3(0, 35, 0);
            wPowerSub.text = "Blessings: ";
            flagStart = true;
        }



        if (Input.GetKeyDown(KeyCode.E))
        {
            if (WPower >= 1)
            {
                AttackRight();               
            }
        }

        if (Input.GetButtonDown("Fire3"))
        {
            Special();
        }
      
    }
}
  
