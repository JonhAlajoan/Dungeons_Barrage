using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modificaCor : MonoBehaviour {


	public Material modifiableColor;
	Color32 colorStart = new Color32(0,120,126,255);
	float duration = 5f;
	public int randomColor;

	void Start(){
		modifiableColor.color = colorStart;
		randomColor = Random.Range (0, 6);
	}

	// Update is called once per frame
	void Update () {
		
		float lerp = Mathf.PingPong (Time.time, duration) / duration;
		switch (randomColor) {
			case 1:
			modifiableColor.color = Color32.Lerp(colorStart,new Color32(10,129,0,255),lerp);
				break;
			case 2:
			modifiableColor.color = Color32.Lerp(colorStart,new Color32(139,0,78,255),lerp);
				break;
			case 3:
			modifiableColor.color = Color32.Lerp(colorStart,new Color32(139,95,0,255),lerp);
				break;
			case 4:
			modifiableColor.color = Color32.Lerp (colorStart, new Color32 (139, 0, 0, 255), lerp);
				break;
			case 5:
			modifiableColor.color = Color32.Lerp (colorStart, new Color32 (22, 0, 139, 255), lerp);
				break;
		}

	}

}
