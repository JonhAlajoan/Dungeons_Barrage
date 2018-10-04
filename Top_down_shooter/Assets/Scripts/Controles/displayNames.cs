using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Steamworks;
using Facepunch.Steamworks;
using UnityEngine.UI;
public class displayNames : MonoBehaviour
{

    public Text displayName;
    //public Text score;
   
    private Leaderboard leaderBoard;
    private Achievements achievements;
    Text[] highscores;

    int vortexesCalled;
    private string nameOfPlayer;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        //
        // Configure for Unity
        // This is VERY important - call this before 
        //
        Facepunch.Steamworks.Config.ForUnity(Application.platform.ToString());

        //
        // Create the steam client using Rust's AppId
        //
       // new Facepunch.Steamworks.Client(757700);

        //
        // Make sure we started up okay
        //
        if (Client.Instance == null)
        {
            Debug.LogError("Error starting Steam!");
            return;
        }
        vortexesCalled = 10;
        
        leaderBoard = Client.Instance.GetLeaderboard("LeaderBoard", Client.LeaderboardSortMethod.Descending, Client.LeaderboardDisplayType.Numeric);
        nameOfPlayer = Client.Instance.Username;
        achievements = Client.Instance.Achievements;

        

    }

    private void OnDestroy()
    {
        if (Client.Instance != null)
        {
            Client.Instance.Dispose();
        }
    }

/*
    public void buttonLeaderBoardEntries()
    {
        RetrieveLeaderBoardEntries();
    }

    public void RetrieveLeaderBoardEntries()
    {
        if (Client.Instance != null)
        {
           achievements.Trigger("2/0",true);
       
            Debug.Log(achievements.);



            if (leaderBoard != null)
            {




                leaderBoard.AddScore(false, 456);
                leaderBoard.FetchScores(Leaderboard.RequestType.Global, 0, 4);

                if (leaderBoard.IsQuerying)
                {
                   displayName.text = ("QUERYING..");
                }

                else if (leaderBoard.Results != null)
                {
                    displayName.text = ("Entrou pra mostrar results");
                    foreach (var result in leaderBoard.Results)
                    {
                       displayName.text = string.Format("{0}. {1} ({2})", result.GlobalRank, result.Name, result.Score);
                    }
                }

                else
                {
                    displayName.text = "No entries!";
                }
            }

            else
            {
                displayName.text = ("no leaderboard found!");
            }
        }
    }
*/


    public void Update()
    {
        if (Client.Instance != null)
        {
            Client.Instance.Update();
           

        }
        

    }





}



