using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyGas : MonoBehaviour {

    GameObject playerObj;

    Collider colliderThis;

    float damage = 2.5f;
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
        colliderThis.enabled = true;
        if (count > 1)
        {
            colliderThis.enabled = false;   
            count = 0;
        }
    }

    void OnTriggerEnter(Collider c)
    {
      IDamageable  enemy = c.GetComponent<IDamageable>();

        if (enemy != null && c.gameObject.tag != "PlayerHP")
        {
            enemy.TakeDamage(damage);
        }
    }

}
