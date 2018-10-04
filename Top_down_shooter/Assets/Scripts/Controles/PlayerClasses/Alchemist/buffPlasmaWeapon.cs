using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffPlasmaWeapon : MonoBehaviour {

    GameObject playerObj;

    Collider colliderThis;

    AlchemistController controllerPlayer;

    float count;

     public ParticleSystem thisParticle;
    public ParticleSystem spark;

    private void Start()
    {
        playerObj = GameObject.FindWithTag("PlayerHP");

        colliderThis = GetComponent<Collider>();

        spark.Stop();


        colliderThis.enabled = false;

        count = 1 * Time.deltaTime;
    }

    private void Update()
    {
        count += 1 * Time.deltaTime;
        if (count > 1)
        {
            colliderThis.enabled = true;
            count = 0;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        controllerPlayer = c.GetComponent<AlchemistController>();

        if (controllerPlayer != null)
        {
            
            controllerPlayer.StartCoroutine("buffAttackSpeed");

            colliderThis.enabled = false;
            var mainParticle = thisParticle.main;
            mainParticle.startColor = new Color(0.64706f,  0.57647f, 0f);
            spark.Play();
            StartCoroutine(disable());
        }
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(2f);
        var mainParticle = thisParticle.main;
        mainParticle.startColor = new Color(0.10196f,  0.09020f,0f);    
        TrashMan.despawn(gameObject);
    }
    private void OnDisable()
    {
        
    }
}
