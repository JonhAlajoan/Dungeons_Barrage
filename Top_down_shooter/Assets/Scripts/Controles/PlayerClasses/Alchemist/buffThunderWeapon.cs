using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffThunderWeapon : MonoBehaviour {

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

            controllerPlayer.StartCoroutine("buffThunder");

            colliderThis.enabled = false;
            var mainParticle = thisParticle.main;
            mainParticle.startColor = new Color(0.49229f,  1f,  0.33922f);
            spark.Play();
            StartCoroutine(disable());
        }
    }

    IEnumerator disable()
    {
        yield return new WaitForSeconds(2f);
        var mainParticle = thisParticle.main;
        mainParticle.startColor = new Color(0f,  0.31765f,  0.30196f);
        TrashMan.despawn(gameObject);
    }
}
