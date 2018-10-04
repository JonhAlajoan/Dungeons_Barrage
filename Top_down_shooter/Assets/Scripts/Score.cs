using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Score : MonoBehaviour {

	public float score;
	Text text;                    

	void Awake ()
	{
		text = GetComponent <Text> ();	
		score = 1 * Time.deltaTime;
	}

	void updateScore(){
		if (GameObject.FindGameObjectWithTag ("Player") != null) 
		{
			score = score + Time.deltaTime;
			text.text = score.ToString("#.0");
		}
	}
	public void updateScoreEnemyDeath(){
		if (GameObject.FindWithTag ("normal")) {
			score += 10;
		} else if (GameObject.FindWithTag ("hard")) {
			score += 20;
		} else if (GameObject.FindWithTag ("insane")) {
		    score += 40;
		}
	}

	void Update ()
	{
		updateScore ();
	}
}
