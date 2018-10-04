    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterExplosion : MonoBehaviour
{
    public float damage = 100f;
    Collider startCollider; 

    void OnEnable()
    {
        startCollider = GetComponent<Collider>();
        startCollider.enabled = false;
        StartCoroutine(delayBeforeExplosion());
    }



    IEnumerator delayBeforeExplosion()
    {
        yield return new WaitForSeconds(2.5f);
        startCollider.enabled = true;
    }


    void OnTriggerEnter(Collider hit)
    {
        IDamageable damageableObject = hit.GetComponent<IDamageable>();
        if (damageableObject != null && hit.gameObject.tag != "PlayerHP")
        {
            damageableObject.TakeDamage(damage); 
        }

    }
}

