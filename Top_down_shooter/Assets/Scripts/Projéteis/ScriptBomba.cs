
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBomba : MonoBehaviour {
	public LayerMask collisionMask;

	public ParticleSystem particleSys;
	public ParticleSystem shockwave;
	public float damage = 10f;
	public float radius;
	float delay = 4.8f;
	bool coRoutineStart = false;
    float count;
	Collider startCollider;

	void Start () {
        radius = 10f;
		startCollider = GetComponent<Collider> ();
		startCollider.enabled = false;
	}

    public void Update()
    {
        count += 1 * Time.deltaTime;
        if (count >= 4.5f)
        {
            startCollider.enabled = true;

            Collider[] initialCollisions = Physics.OverlapSphere(transform.position, radius, collisionMask);
            if (initialCollisions.Length > 0)
            {
                OnHitObject(initialCollisions[0]);
            }
            count = 0;
        }
        
    }

    void OnHitObject(Collider hit)
    {
        IDamageable damageableObject = hit.GetComponent<IDamageable>();
        if (damageableObject != null) 
        {
            damageableObject.TakeDamage(damage);            
        }

       

    }


    /*void OnTriggerEnter(Collider c)
	{
		IDamageable damageableObject = c.GetComponent<IDamageable> ();
		if (damageableObject != null) { 
			damageableObject.TakeDamage(damage);
		}
		startCollider.enabled = false;
        TrashMan.despawn(gameObject);
    }*/
}