using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giroPortal : MonoBehaviour {
	public GameObject cubo;
	IEnumerator rotacao(){
		iTween.RotateBy (cubo, iTween.Hash (
			"y", 0.20f,
			"Time",2f	
		));
		yield return null;
	}
	void Update () {
		StartCoroutine ("rotacao");
	}
}
