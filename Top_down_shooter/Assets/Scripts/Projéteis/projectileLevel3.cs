using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileLevel3 : MonoBehaviour {

	public LayerMask collisionMask;
	public float speed;
	public float damage = 30f;
	public Transform Enemy_Hit_vfx;
	LivingEntity targetEntity;
	Transform target;
	float lifetime = 5f;
	float skinWidth = .1f;
	public float count;
	public int idTipoProjetil = 1;


	void Start() {

		Collider[] initialCollisions = Physics.OverlapSphere (transform.position, .2f, collisionMask);
		if (initialCollisions.Length > 0) {
			OnHitObject(initialCollisions[0]);
		}
		
	}

	public void SetSpeed(float newSpeed) {
		speed = newSpeed;
    }

    
	void Update () {
        count += 1 * Time.deltaTime;
        if (count >= 5f)
        {
            TrashMan.despawn(gameObject);
            count = 0;
        }
        float moveDistance = speed * Time.deltaTime;
		transform.Translate (Vector3.forward * moveDistance);

		CheckCollisions (moveDistance);
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
		if (damageableObject != null && flag.enabled==true) {			
			TrashMan.spawn ("hit", gameObject.transform.position, gameObject.transform.rotation);
			damageableObject.TakeHit(damage,hit);
		}
		//GameObject.Destroy (gameObject);

	}

	void OnHitObject(Collider c) {
		IDamageable damageableObject = c.GetComponent<IDamageable> ();
		if (damageableObject != null) {
			damageableObject.TakeDamage(damage);
		}
	}
}
