using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class ShamanController : ClassesPlayer{

    public int typeOfRuneBeingUsed;

    public GameObject[] threeForms;

    public string[] comboTriggersKen;
    public string[] comboTriggrsKenKick;

    private int comboIndex = 0;
    private float resetTimer;

    public bool StateJera;
    public bool StateIsa;
    public bool StateKen;

    bool stopFlag;

    public Animator[] animators;

    int teste;

    protected override void Start()
    {
        base.Start();
        teste = 0;
    }

    public void SetStateOfRunes(bool stateOfRune, string runeBeingUpdated)
    {
        if(runeBeingUpdated == "StateKen")
        {
            StateKen = stateOfRune;
        }

        if(runeBeingUpdated == "StateIsa")
        {
            StateIsa = stateOfRune;
        }

        if(runeBeingUpdated == "StateJera")
        {
            StateJera = stateOfRune;
        }
    }

    public override void Attack()
    {
        if (comboIndex < comboTriggersKen.Length)
        {

            sfxController.PlaySFXSounds("bullet_arcane");
            nextShotTime = Time.time + msBetweenShots / 1000;
            if (animaController.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                int NumRandom = Random.Range(0, 2); 
                if(NumRandom == 0)
                {
                    for(int i = 0;i<comboTriggersKen.Length;i++)
                    {
                        comboTriggersKen[i] = i + " " + "Combo_Punch";
                    }
                }

                if (NumRandom == 1)
                {
                    for (int i = 0; i < comboTriggersKen.Length; i++)
                    {
                        comboTriggersKen[i] = i + " " + "Combo_Punch" + " " + "2";
                    }
                }
            }
            
            animaController.SetTrigger(comboTriggersKen[comboIndex]);
            comboIndex++;
        }
        resetTimer = 0;
    }

    public override void AttackRight()
    {
        if (comboIndex < comboTriggrsKenKick.Length)
        {

            sfxController.PlaySFXSounds("bullet_arcane");
            nextShotTime = Time.time + msBetweenShots / 1000;

           if (animaController.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                int NumRandom = Random.Range(0, 2);
                if (NumRandom == 0)
                {
                    for (int i = 0; i < comboTriggrsKenKick.Length; i++)
                    {
                        comboTriggrsKenKick[i] = i + " " + "Combo_Kick";
                    }
                }

                if (NumRandom == 1)
                {
                    for (int i = 0; i < comboTriggrsKenKick.Length; i++)
                    {
                        comboTriggrsKenKick[i] = i + " " + "Combo_Kick" + " " + "2";
                    }
                }
           }
            animaController.SetTrigger(comboTriggrsKenKick[comboIndex]);
            comboIndex++;
        }
        resetTimer = 0;
    }

    IEnumerator buffTime()
    {
        GameObject newVortex = TrashMan.spawn("FireSpecial", gameObject.transform.position, gameObject.transform.rotation);
        newVortex.transform.parent = gameObject.transform;
        animaController.SetFloat("AnimationSpeed", 1);
        msBetweenShots = msBetweenShots / 2;
        yield return new WaitForSeconds(5f);
        TrashMan.despawn(newVortex);
        animaController.SetFloat("AnimationSpeed", 0.5f);
        msBetweenShots = msBetweenShots * 2;
    }

    public void changeTypeOfForm()
    {
        if(typeOfRuneBeingUsed == 1)
        {
            textWPower.text = "Ken";
            foreach (GameObject form in threeForms)
            {
                if (form.name == "KenMain")
                {
                    form.SetActive(true);
                }
                else
                {
                    form.SetActive(false);
                }
            }
            foreach (Animator animator in animators)
            {
                if (animator.name == "KenMain")
                {
                    animaController = animator;   
                }
             
            }

        }

        if(typeOfRuneBeingUsed == 2)
        {
            textWPower.text = "Isa";
            foreach (GameObject form in threeForms)
            {
                if (form.name == "IsaMain")
                {
                    form.SetActive(true);
                }
                else
                {
                    form.SetActive(false);
                }

            }

            foreach (Animator animator in animators)
            {
                if (animator.name == "IsaMain")
                {
                    animaController = animator;
                }
                
            }
        }

        if(typeOfRuneBeingUsed == 3)
        {
            textWPower.text = "Jera";
            foreach (GameObject form in threeForms)
            {
                if (form.name == "JeraMain")
                {
                    form.SetActive(true);
                    
                }
                else
                {
                    form.SetActive(false);
                }
            }

            foreach (Animator animator in animators)
            {
                if (animator.name == "JeraMain")
                {
                    animaController = animator;

                }
                
            }

        }
        
    }

    public override void Special()
    {
      if(specialQuantity>0)
        {
            if (typeOfRuneBeingUsed == 1)
            {
                StartCoroutine(buffTime());
            }

            if (typeOfRuneBeingUsed == 2)
            {
                TrashMan.spawn("MarkIsa", crosshairs.transform.position, new Quaternion(0, 0, 0, 0));
                StartCoroutine(delayBeforeIce());
            }

            if (typeOfRuneBeingUsed == 3)
            {
                TrashMan.spawn("Jera_Special", gameObject.transform.position, new Quaternion(0, 0, 0, 0));
            }
            specialQuantity--;
        }
        
    }

    IEnumerator delayBeforeIce()
    {
        yield return new WaitForSeconds(0.4f);
        TrashMan.spawn("Projectile_Ice", new Vector3(crosshairs.transform.position.x, (crosshairs.transform.position.y + 30), crosshairs.transform.position.z), new Quaternion(0, 0, 0, 0));
    }

    public override void Update()
    {
        base.Update();

        if(hasFoundAllReferences && stopFlag == false)
        {
            wPowerSub.text = "      Rune: ";
            comboIndex = 0;
            msBetweenShots = 500;

            typeOfRuneBeingUsed = Random.Range(1, 4);

            if (typeOfRuneBeingUsed == 1)
            {
                SetStateOfRunes(true, "StateKen");
                SetStateOfRunes(false, "StateIsa");
                SetStateOfRunes(false, "StateJera");
            }

            if (typeOfRuneBeingUsed == 2)
            {
                SetStateOfRunes(false, "StateKen");
                SetStateOfRunes(true, "StateIsa");
                SetStateOfRunes(false, "StateJera");
            }

            if (typeOfRuneBeingUsed == 3)
            {
                SetStateOfRunes(false, "StateKen");
                SetStateOfRunes(false, "StateIsa");
                SetStateOfRunes(true, "StateJera");
            }
            changeTypeOfForm();
            
            stopFlag = true;
        }
     
        if (comboIndex > 0)
        {
            resetTimer += Time.deltaTime;
          
            if (resetTimer > 1f)
            {
                animaController.SetTrigger("reset");
                comboIndex = 0;
                animaController.ResetTrigger("0 Combo_Punch");
                animaController.ResetTrigger("1 Combo_Punch");
                animaController.ResetTrigger("2 Combo_Punch");

                animaController.ResetTrigger("0 Combo_Punch 2");
                animaController.ResetTrigger("1 Combo_Punch 2");
                animaController.ResetTrigger("2 Combo_Punch 2");

                animaController.ResetTrigger("0 Combo_Kick");
                animaController.ResetTrigger("1 Combo_Kick");
                animaController.ResetTrigger("2 Combo_Kick");

                animaController.ResetTrigger("0 Combo_Kick 2");
                animaController.ResetTrigger("1 Combo_Kick 2");
                animaController.ResetTrigger("2 Combo_Kick 2");
            }
        }

        if(comboIndex > 2 && animaController.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animaController.IsInTransition(0))
        {
            animaController.SetTrigger("reset");
            comboIndex = 0;
        }
        
    }
}
