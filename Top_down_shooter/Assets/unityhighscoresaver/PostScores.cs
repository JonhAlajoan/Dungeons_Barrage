using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
public class PostScores : MonoBehaviour {


	public GameObject leaderBoardPopUp;
	public Text score;
	public Text scoreFim;
	float numScore;
	public Text nick;
	string nickAux;
	public GameObject leaderBoard;
	public GameObject popUpCadastraHS;
	public GameObject canvas;
	public PostProcessingProfile cameraBlur;

    public LoadScores loadScoreScript;
	int flag = -1;

	void Start () {
		Cursor.visible = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (GameObject.FindGameObjectWithTag ("Player") == null) {
			Cursor.visible = true;
			cameraBlur.depthOfField.enabled = true;
			popUpCadastraHS.SetActive (true);
			canvas.SetActive (false);

			numScore = score.GetComponent<Score> ().score;

		} /*else {
			cameraBlur.depthOfField.enabled = false;
		}*/
		scoreFim.text = numScore.ToString("#.0");

		if (flag == 1) 
		{
			popUpCadastraHS.SetActive (false);
		}

	}

	public void postScore()
	{		
		nickAux = nick.GetComponent<Text> ().text;

		HighscoreSaver.postScore("|" + nickAux + "|", numScore.ToString(), this);
		leaderBoard.SetActive (true);
		flag = 1;

        loadScoreScript.loadScore();

	}


}
