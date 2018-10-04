using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using System;

public class WitchController : ClassesPlayer {
    
    bool allowTogglePower = true;
   
    public Transform muzzle2;
    public Transform muzzle3;

    float timeReference;
    //
   
 
    int flag = 0;
   
    SmoothFollow cameraSpeed;

    Vector3 movement;

    Collider thisCollider;

    bool flagStart;

    void Awake()
    {
    
        Cursor.visible = false;
    }


    protected override void Start()
    {
        //Base.Start uses the LivingEntity protected function to start a player's HP
        base.Start();
        flagStart = false;

    }

    public override void AttackRight()
    {
        throw new NotImplementedException();
    }

    public override void Attack()
    {
        if (Time.time > nextShotTime)
        {
            
            nextShotTime = Time.time + msBetweenShots / 1000;
            sfxController.PlaySFXSounds("WitchProjectile");
            TrashMan.spawn("WitchPreShoot", muzzle.transform.position, muzzle.transform.rotation);
            GameObject modifyPositionSpawn = TrashMan.spawn("ProjectileDarkness", muzzle.transform.position, muzzle.transform.rotation);
            GameObject modifyPositionSpawn2 = TrashMan.spawn("ProjectileDarkness", muzzle2.transform.position, muzzle2.transform.rotation);
            GameObject modifyPositionSpawn3 = TrashMan.spawn("ProjectileDarkness", muzzle3.transform.position, muzzle3.transform.rotation);
            animaController.SetTrigger("attack");
     

        }
    }

    public override void Special()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;

            if (specialQuantity >= 1)
            {
                sfxController.PlaySFXSounds("ZaWarudo");
                animaController.SetTrigger("callVortex");
                GameObject warudoEffect = TrashMan.spawn("Za_Warudo", specialMuzzle.transform.position, specialMuzzle.transform.rotation);

                warudoEffect.transform.parent = specialMuzzle;
                specialQuantity -= 1;
                StartCoroutine("zaWarudoEffect");
                
            }
            
        }
    }

        IEnumerator zaWarudoEffect()
        {

        yield return new WaitForSeconds(0.1f);
            postProcessing.chromaticAberration.enabled = true;
            var chromAberration = postProcessing.chromaticAberration.settings;
            chromAberration.intensity = 3f;
        postProcessing.chromaticAberration.settings = chromAberration;
            thisCollider.enabled = false;

        yield return new WaitForSeconds(3f);

        postProcessing.chromaticAberration.enabled = false;
        postProcessing.motionBlur.enabled = true;

        var colorGrading = postProcessing.colorGrading.settings;
        colorGrading.basic.saturation = 0.16f;
        postProcessing.colorGrading.settings = colorGrading;
        
        Time.timeScale = 0.01f;
        
        cameraSpeed.setCameraSpeed(cameraSpeed.cameraSpeed *= 50);
        msBetweenShots = 4;
        nextShotTime = 0;
        

        animaController.speed *= 100;
        nextShotTime = Time.time + 0 / 1000;
        yield return new WaitForSeconds(0.01f);
        controller.SimpleMove(Vector3.zero);

        yield return new WaitForSeconds(0.1f);

        Time.timeScale = 1f;
        thisCollider.enabled = true;
        speed = 15;
        postProcessing.motionBlur.enabled = false;

        var colorsGrading = postProcessing.colorGrading.settings;
        colorsGrading.basic.saturation = 0.68f;
        postProcessing.colorGrading.settings = colorsGrading;
        cameraSpeed.setCameraSpeed(15);
        msBetweenShots = 200;
        animaController.speed = 1;
        }


     
       public override void Update()
        {

        base.Update();

        if(hasFoundAllReferences && flagStart == false)
        {
            thisCollider = gameObject.GetComponent<Collider>();
            
            timeReference = 1 * Time.deltaTime;

            cameraSpeed = mainCamera.GetComponent<SmoothFollow>();

            wPowerSub.text = " ";

            textWPower.text = " ";

            msBetweenShots = 200;
            speed = 10;
            flagStart = true;
        }


        if (Time.timeScale == 1f)
            {
                movement = new Vector3(hAxis, -10.0f, vAxis) * speed * Time.deltaTime;
                controller.Move(movement);
          }
        else
        {
            if(speed <= 300)
            {
                speed += speed * 100 * Time.deltaTime;
            }

            movement = new Vector3(hAxis * 2, -10.0f, vAxis * 2) * (Time.deltaTime * 70) * speed;
            controller.Move(movement);
        }

        if (Input.GetMouseButton(0))
            {

                 if (Time.time > nextShotTime)
                 {

                Attack();                    
                   
                 }

            }



    }
    }

