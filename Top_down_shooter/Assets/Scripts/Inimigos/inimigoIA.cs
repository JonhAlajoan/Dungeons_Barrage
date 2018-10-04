using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoIA : MonoBehaviour {
	/*
	public float walkMoveForce=0f;
	public float runMoveForce=0f;
	public float moveForce=0f;
	public LayerMask whatIsPlayer;
	public LayerMask whatIsObstacle;
	private Rigidbody rbody;
	public GameObject playerObject;
	public float wallCheckDist=0f;
	private Vector3 moveDir;
	private bool targetFound;
	public float distanceFromTarget=0f;
	public float safeDistance = 0f;


	void Start () {
		rbody = GetComponent<Rigidbody> ();
		moveDir = ChooseDirection ();
		transform.rotation = Quaternion.LookRotation (moveDir);
		moveForce = walkMoveForce;
	}
	
	// Update is called once per frame
	void Update () {
		if (targetFound) {
		} else {
			LookForTarget ();
		}

		distanceFromTarget = Vector3.Distance (transform.position, playerObject.transform.position);
		
	}

	void Hide(){
		if (distanceFromTarget < safeDistance) {
			RunToHide();
		} else {
			moveForce = walkMoveForce;
			targetFound = false;
			moveDir = ChooseDirection ();
			transform.rotation = Quaternion.LookRotation (moveDir);
		}
	}

	void RunToHide(){
	}

	Vector3 ChooseDirection(){
		System.Random ran = new System.Random ();
		int i = ran.Next (0, 3);
		Vector3 temp = new Vector3 ();

		if (i == 0)
			temp = transform.forward;
		else if (i == 1)
			temp = -transform.forward;
		else if (i == 2)
			temp == transform.right;
		else if (i == 3)
			temp = -transform.right;

		return temp;
	}

	void LookForTarget(){
		Move ();
		targetFound = Physics.Raycast (transform.position, transform.forward, Mathf.Infinity, whatIsPlayer);
	}

	void Move(){
		rbody.velocity = moveDir * moveForce;
		if(Physics.Raycast(transform.position, transform.forward,wallCheckDist,whatIsObstacle){
			moveDir=ChooseDirection();
			transform.rotation=Quaternion.LookRotation(moveDir);
		}
	}*/
}
