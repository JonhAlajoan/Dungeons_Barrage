using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(GUIText))]
public class HighScoreTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        HighscoreSaver.loadScores(this);
        GetComponent<GUIText>().text = "Loading Highscores";
	}
	
	// Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HighscoreSaver.postScore("brabbel", "4648209", this);
        }
	}
    public void OnHighscoreLoaded(List<HighscoreSaver.Highscore> highscores)
    {
        Debug.Log("Updating highscores!");
        string text = "";
        foreach (HighscoreSaver.Highscore hs in highscores)
        {
            text += hs.name + "\t\t" + hs.score + "\n";
        }
        GetComponent<GUIText>().text = text;
    }
    public void OnHighscorePosted()
    {
        Debug.Log("Post successful, updating scores!");
        HighscoreSaver.loadScores(this);
    }
}
