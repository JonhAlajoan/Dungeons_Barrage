using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexKen : MonoBehaviour {

    public LayerMask collisionMask;
    public float damage = 5f;
    public float radius;

    void Start()
    {
        radius = 10f;

    }

    public void Update()
    {   

            Collider[] initialCollisions = Physics.OverlapSphere(transform.position, radius, collisionMask);
            if (initialCollisions.Length > 0)
            {
                OnHitObject(initialCollisions[0]);
            }
        
    }

   

    void OnHitObject(Collider hit)
    {
        IDamageable damageableObject = hit.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(damage);
            Debug.Log("Dano causado: " + damage + "Segundo: " + 1 * Time.deltaTime);
        }
    }
}
