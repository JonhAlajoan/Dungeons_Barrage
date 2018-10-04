using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScores : MonoBehaviour {

	public Text score;
	public List<Text> listaScores = new List<Text>();

	public void loadScore() 
	{		
		HighscoreSaver.loadScores (this);
		score.text = "Loading...";
	}

	public void OnHighscoreLoaded(List<HighscoreSaver.Highscore> highscores)
	{
		Debug.Log("Updating highscores!");
		string text = "";
		foreach (HighscoreSaver.Highscore hs in highscores)
		{
			text += hs.name + "\t\t" + hs.score + "\n";
		}
		score.text = text;
	}


}