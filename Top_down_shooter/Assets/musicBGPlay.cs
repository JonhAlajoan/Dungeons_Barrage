using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicBGPlay : MonoBehaviour {

	public audioController controller;
	public AudioClip seconds;
	void Start(){
		seconds = controller.GetComponent<AudioClip> ();
		controller = controller.GetComponent<audioController> ();
		controller.PlayRandomMusic ();	
	}
	/*void Update(){
		if(seconds.length<=0)
		controller.PlayRandomMusic ();
	}*/
}
