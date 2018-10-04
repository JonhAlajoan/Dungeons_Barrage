using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire: MonoBehaviour {

	public LayerMask collisionMask;
	public float speed;
	public float damage = 1;
	public Transform Enemy_Hit_vfx;
	LivingEntity targetEntity;
	Transform target;
	float lifetime = 4;
	float skinWidth = .1f;
	public float count=0;
	void Start() {

		Destroy (gameObject, lifetime);

		Collider[] initialCollisions = Physics.OverlapSphere (transform.position, .2f, collisionMask);
		if (initialCollisions.Length > 0) {
			OnHitObject(initialCollisions[0]);
		}
	}

	public void SetSpeed(float newSpeed) {
		speed = newSpeed;
	}

	void Update () {
		float moveDistance = speed * Time.deltaTime;
		CheckCollisions (moveDistance);
		transform.Translate (Vector3.forward * moveDistance);
		count += 1 * Time.deltaTime;
		if (count >= 1.5f) {
			transform.Translate (-Vector3.forward * moveDistance * 2);
			CheckCollisions (-moveDistance);
		}

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
			Transform hit_vfx_clone = (Transform) Instantiate(Enemy_Hit_vfx, transform.position, transform.rotation);
			damageableObject.TakeHit(damage,hit);
		}
		GameObject.Destroy (gameObject);

	}

	void OnHitObject(Collider c) {
		IDamageable damageableObject = c.GetComponent<IDamageable> ();
		if (damageableObject != null) {
			damageableObject.TakeDamage(damage);
		}
		GameObject.Destroy (gameObject);
	}
}
