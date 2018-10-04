using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitarRedorOrbe : MonoBehaviour {

	public GameObject centro;
	public float velocidade;


	void Update () {
		transform.RotateAround (centro.transform.position, new Vector3(0.0f,2.0f,0.0f), 100 * Time.deltaTime * velocidade);
	}
}

