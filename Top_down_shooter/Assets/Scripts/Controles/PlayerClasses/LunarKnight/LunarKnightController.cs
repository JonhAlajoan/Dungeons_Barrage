using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using System;

public class LunarKnightController : ClassesPlayer
{

    private int randomIndexNumber;

    public string[] comboParams;

    float count;

    Collider thisCollider;

    bool flagStop;

    void Awake()
    {
     
        Cursor.visible = false;
    }


    protected override void Start()
    {
      
        base.Start();

        flagStop = false;
    }


    public override void Special()
    {
       if (specialQuantity >= 1)
       {
                sfxController.PlaySFXSounds("ZaWarudo");
                animaController.SetTrigger("callVortex");
                Heal(2);
                StartCoroutine(DisableColliderSpecial());
                specialQuantity--;
       }
        animaController.SetTrigger("reset");
    }

    IEnumerator DisableColliderSpecial()
    {
        thisCollider.enabled = false;
        speed += 10;
        yield return new WaitForSeconds(6f);
        speed -= 10;
        thisCollider.enabled = true;
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }

    public override void AttackRight()
    {
        animaController.SetTrigger("reset");
        animaController.SetTrigger("attackRanged");
        animaController.SetTrigger("reset");
    }

    public override void Update()
    {
        base.Update();

        if(hasFoundAllReferences && flagStop == false)
        {
            thisCollider = gameObject.GetComponent<Collider>();



            wPowerSub = GameObject.FindGameObjectWithTag("textWpowerSub").GetComponent<Text>();
            wPowerSub.text = " ";

            msBetweenShots = 1200;

            randomIndexNumber = 0;
            count = 1 * Time.deltaTime;
            flagStop = true;
        }

        count += 1 * Time.deltaTime;

        if(count>2)
        {
            randomIndexNumber = UnityEngine.Random.Range(0, 4);
            count = 0;
        }


        if (Input.GetMouseButton(0) && randomIndexNumber <= comboParams.Length)
        {

            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + msBetweenShots / 1000;
                for (int i =0;i<comboParams.Length;i++)
                {
                     animaController.ResetTrigger(comboParams[randomIndexNumber]);
                }   
                animaController.SetTrigger(comboParams[randomIndexNumber]); 
            }
            animaController.SetTrigger("reset");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }

        textWPower.text = " ";

    }
}

