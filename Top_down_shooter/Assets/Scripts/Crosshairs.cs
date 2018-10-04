using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour {
	public LayerMask targetMask;

	void Update () {
		transform.Rotate(Vector3.up * 40 * Time.deltaTime);
	}

	public void DetectTargets(Ray ray){
		if (Physics.Raycast (ray, 100, targetMask)) {
		}	
}
}
