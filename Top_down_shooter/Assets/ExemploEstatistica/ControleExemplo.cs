using UnityEngine;
using System.Collections;

public class ControlleExemplo : MonoBehaviour {

	Camera viewCamera;

	public Transform crosshairs;

	public Transform muzzle;

	public Projectile projectile;
	public float msBetweenShots = 100;
	public float muzzleVelocity = 35;
	float nextShotTime;




	public float gravity=10.0f;
	private Vector3 moveDirection = Vector3.zero;


	void Start()
	{
		
		viewCamera = Camera.main;


	}

	//Função para fazer atirar


	public void LookAt(Vector3 lookPoint) {
		Vector3 heightCorrectedPoint = new Vector3 (lookPoint.x, transform.position.y, lookPoint.z);
		transform.LookAt (heightCorrectedPoint);
	}

	public float GunHeight{
		get{
			return muzzle.position.y;
		}
	}

	public void Shoot() {

		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShots / 1000;
			Projectile newProjectile = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;

			newProjectile.SetSpeed (muzzleVelocity);

			newProjectile.transform.LookAt(crosshairs.position);

			newProjectile.transform.Rotate(0,0,0);



		}
		//animController.SetInteger("IdleToAttack", 2);
	}




	void Update () 
	{

		//Faz o boneco virar de acordo com o mouse
		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.up * GunHeight);
		float rayDistance;

		if (groundPlane.Raycast(ray,out rayDistance)) {
			Vector3 point = ray.GetPoint(rayDistance);
			//Debug.DrawLine(ray.origin,point,Color.red);
			this.LookAt(point);

			crosshairs.position = point;
		}
		//-------------------------------------------

		if (Input.GetMouseButton(0)) {
			Debug.Log ("Atirado");
			Shoot();
		}
			

	}
}
