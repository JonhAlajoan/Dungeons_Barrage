using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modificaAlphaText : MonoBehaviour {

    float counter;
	// Use this for initialization
	void Start () {
        counter =5;
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, counter);
	}
}
