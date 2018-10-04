using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using System;

public class SolarKnightController : ClassesPlayer
{
    
    bool allowTogglePower = true;
    float timeReference;
    int flag = 0;
    Vector3 movement;

    public string[] comboParams;
    private int comboIndex = 0;
    private float resetTimer;

    public Transform crossPositionBombMoment;

    public bool isSpecialActive;
    public bool isSunInteractive;
    protected Collider thisCollider;
    protected Animator camAnimatorController;
    bool stopflag;

    void Awake()
    {
        Cursor.visible = false;
    }


    protected override void Start()
    {
        base.Start();
        stopflag = false;
        camAnimatorController = mainCamera.GetComponent<Animator>();
        thisCollider = gameObject.GetComponent<Collider>();
        timeReference = 1 * Time.deltaTime;
        wPowerSub.text = " ";
        msBetweenShots = 600;
        isSpecialActive = false;
        isSunInteractive = false;
    }

    public void ZoomOut()
    {
        camAnimatorController.SetBool("CamZoomOut", true);
        animaController.SetBool("callVortex", true);
    }

    public void ZoomIn()
    {
        StopAllCoroutines();
        camAnimatorController.SetBool("CamZoomOut", false);
        animaController.SetBool("callVortex", false);
        controller.enabled = true;
        thisCollider.enabled = true;
    }

    public IEnumerator ZoomInCooldown()
    {
        ZoomOut();
        yield return new WaitForSeconds(10.0f);
        camAnimatorController.SetBool("CamZoomOut", false);
        animaController.SetBool("callVortex", false);
        controller.enabled = true;
        thisCollider.enabled = true;
    }

    public override void Attack()
    {
        if(comboIndex < comboParams.Length && isSpecialActive == false)
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + msBetweenShots / 1000;
                animaController.SetTrigger(comboParams[comboIndex]);
                comboIndex++;
            }
            resetTimer = 0f;
        }
    }

    public override void AttackRight()
    {
        animaController.SetTrigger("reset");
        animaController.SetTrigger("attack_ranged");
    }

    public override void Special()
    {
        if(specialQuantity>0)
        {
            GameObject Special = TrashMan.spawn("Sol", specialMuzzle.transform.position, new Quaternion(0, 0, 0, 0));
            Special.transform.parent = specialMuzzle.parent;
            controller.enabled = false;
            thisCollider.enabled = false;
            isSpecialActive = true;
            StartCoroutine(ZoomInCooldown());
            specialQuantity--;
        }
        
    }

    public override void Update()
    {

        base.Update();

        if (hasFoundAllReferences && stopflag == false)
        {
            camAnimatorController = mainCamera.GetComponent<Animator>();
            thisCollider = gameObject.GetComponent<Collider>();
            wPowerSub.text = "    ";
            comboIndex = 0;
            msBetweenShots = 500;
            stopflag = true;
        }

        if (Input.GetMouseButtonDown(0) && isSpecialActive == true)
        {
            isSunInteractive = true;
            crossPositionBombMoment = crosshairs;
            animaController.SetTrigger("SpecialActive");
        }

        if (comboIndex > 0)
        {
            resetTimer += Time.deltaTime;
                if (resetTimer > 1f)
                {
                 animaController.SetTrigger("reset");
                 comboIndex = 0;
                }
        }
    }
}



