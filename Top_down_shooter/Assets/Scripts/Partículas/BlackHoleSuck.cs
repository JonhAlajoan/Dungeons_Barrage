using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleSuck : MonoBehaviour {
	public Transform blackHoleCenter;
	Transform objeto;
	Projectile_enemy projectileWindContact;
	projectileCannonBall projectileFireContact;
	ProjectileFrozen projectileFrozenContact;
	projectile_Carranca projectileCarrancaContact;
	float countdown=2.0f;
	float speedAtt = 3.0f;
	float rotacao = -15f;

	void Start(){
		countdown *= Time.deltaTime;
	}


	void Update(){
		rotacao *= Time.deltaTime;
	}




	void OnTriggerEnter(Collider c){

		Transform objeto = c.GetComponent<Transform>();


		if (c.gameObject.tag == "projectileWind") {
			objeto.transform.LookAt(blackHoleCenter);
			projectileWindContact = c.GetComponent<Projectile_enemy>();
			BoxCollider collider = projectileWindContact.GetComponent<BoxCollider> ();
		
			projectileWindContact.SetSpeed(speedAtt);
			collider.enabled = false;
			Destroy (c.gameObject, 2.5f);
		}

		if (c.gameObject.tag == "projectileFire") {
			objeto.transform.LookAt(blackHoleCenter);
			projectileFireContact = c.GetComponent<projectileCannonBall>();
			BoxCollider collider = projectileFireContact.GetComponent<BoxCollider> ();

			projectileFireContact.SetSpeed(speedAtt);
			collider.enabled = false;
			Destroy (c.gameObject, 2.5f);
		}

		if (c.gameObject.tag == "projectileFrozen") {
			objeto.transform.LookAt(blackHoleCenter);
			projectileFrozenContact = c.GetComponent<ProjectileFrozen>();
			BoxCollider collider = projectileFrozenContact.GetComponent<BoxCollider> ();

			speedAtt = 1.5f;
			projectileFrozenContact.SetSpeed(speedAtt);
			collider.enabled = false;
			Destroy (c.gameObject, 2.5f);
		}

		if (c.gameObject.tag == "projectileCarranca") {
			objeto.transform.LookAt(blackHoleCenter);
			projectileCarrancaContact = c.GetComponent<projectile_Carranca>();
			BoxCollider collider = projectileCarrancaContact.GetComponent<BoxCollider> ();

			speedAtt = 1.5f;
			projectileCarrancaContact.SetSpeed(speedAtt);
			collider.enabled = false;
			Destroy (c.gameObject, 2.5f);
		}

	}
		
}
