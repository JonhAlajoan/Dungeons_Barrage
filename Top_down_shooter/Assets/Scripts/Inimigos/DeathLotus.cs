using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLotus : MonoBehaviour {

	public GameObject crystal;
	public GameObject body;

	void Update () {
		if (crystal == null) {
			Destroy (body);
		}	
	}
}
