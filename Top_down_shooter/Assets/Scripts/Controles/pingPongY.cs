using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingPongY : MonoBehaviour {

	public Transform objeto;
	// Update is called once per frame
	void Update () {
		objeto.transform.position = new Vector3(objeto.transform.position.x, Mathf.Lerp(1, 3.5f, Mathf.PingPong(Time.time , 2f)), objeto.transform.position.z);
	}
}
