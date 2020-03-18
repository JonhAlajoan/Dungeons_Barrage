using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Score : MonoBehaviour {

	public float score;
	Text text;
    public int scoreInt;

	void Awake ()
	{
		text = GetComponent <Text> ();	
		score = 1 * Time.deltaTime;
	}

	void updateScore(){
		if (GameObject.FindGameObjectWithTag ("Player") != null) 
		{
			score = score + Time.deltaTime;
            scoreInt = Convert.ToInt32(score);
			text.text = scoreInt.ToString("#");
		}
	}
	public void updateScoreEnemyDeath(){
		if (GameObject.FindWithTag ("normal")) {
			score += 10;
		} else if (GameObject.FindWithTag ("hard")) {
			score += 15;
		} else if (GameObject.FindWithTag ("insane")) {
		    score += 20;
		}
	}

	void Update ()
	{
		updateScore ();
	}
}
