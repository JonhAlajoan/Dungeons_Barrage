using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jera_Vortex_Orb : MonoBehaviour {
    public LayerMask collisionMask;



    public float damage = 5f;


    void OnTriggerEnter(Collider hit)
    {
        IDamageable damageableObject = hit.GetComponent<IDamageable>();

        if (damageableObject != null && hit.gameObject.tag!="PlayerHP")
        {
            TrashMan.spawn("runeJeraUsed", hit.transform.position, hit.transform.rotation);
            damageableObject.TakeDamage(damage);
        }

    }
}
