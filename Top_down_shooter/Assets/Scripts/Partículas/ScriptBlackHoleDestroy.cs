using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlackHoleDestroy : MonoBehaviour {

	public Transform blackHoleCenter;
	public float speed = 10.0f;
	Transform centerMove;
	GameObject objeto;
	int x=1;
	void Start(){
		Transform centerMove = blackHoleCenter.GetComponent<Transform> ();

	}

	void update(){
		speed *= Time.deltaTime;
	//	transform.Translate
		//transform.position= transform.position - new Vector3(0,0,-1); 

	}
	void OnTriggerEnter(Collider c){
		GameObject objeto = c.GetComponent<GameObject>();

		if (c.gameObject.tag == "Puxavel") {
			Destroy (objeto.gameObject);

		}

	}
}
