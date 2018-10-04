using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFrozen: MonoBehaviour {

	public LayerMask collisionMask;
	public float speed;
	public float damage = 1;
	public Transform Enemy_Hit_vfx;
	LivingEntity targetEntity;
	Transform target;
	float lifetime = 5f;
	float skinWidth = .1f;
	public float count=0;
	public int idTipoProjetil = 1;
    float acceleration;
    float wave;
    float angle = 380;

	void Start() {
        acceleration = 1f;
		Collider[] initialCollisions = Physics.OverlapSphere (transform.position, .2f, collisionMask);
		if (initialCollisions.Length > 0) {
			OnHitObject(initialCollisions[0]);
		}

	}

	public void SetSpeed(float newSpeed) {
		speed = newSpeed;
	}

	void Update () {
        int randomDir = Random.Range(0, 1);

        float moveDistance = speed * acceleration * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDistance);
        wave = Mathf.Sin(Mathf.Cos(angle) * 2);
        count += 1 * Time.deltaTime;
       transform.Rotate(0, wave, 0);
       
        if (count >= 1)
        {
            acceleration = 1f;           
        }
    
        if (count >= 3)
        {
            TrashMan.despawn(gameObject);
            count = 0;
        }
        CheckCollisions(moveDistance);
    }

	void CheckCollisions(float moveDistance) {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide)) {
			OnHitObject(hit);
		}
	}

	void OnHitObject(RaycastHit hit) {
		BoxCollider flag = this.GetComponent<BoxCollider> ();
		IDamageable damageableObject = hit.collider.GetComponent<IDamageable> ();
		if (damageableObject != null) {			
			TrashMan.spawn ("hitEnemyFrozen", gameObject.transform.position, gameObject.transform.rotation);
			damageableObject.TakeHit(damage,hit);
		}
		TrashMan.despawn (gameObject);
		//GameObject.Destroy (gameObject);

	}

	void OnHitObject(Collider c) {
		IDamageable damageableObject = c.GetComponent<IDamageable> ();
		if (damageableObject != null) {
			damageableObject.TakeDamage(damage);
		}
		TrashMan.despawn (gameObject);
	}
}
