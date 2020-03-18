using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.UI;
using System.Threading;

public class LeaderboardCell
{
    public Image playerImage;
    public Text playerName;
    public Text playerScore;
}

public class SteamLeaderboard : MonoBehaviour
{
    private const string m_leaderboardName = "db_teste_board";

    private static int m_leaderboardCount;

    private static SteamLeaderboard_t m_steamLeaderBoard;

    private static SteamLeaderboardEntries_t m_leaderboardEntries;

    //Used by the method OnLeaderBoardFindResult() to check if the leaderboard was found or not.
    private static bool m_leaderboardInitiated;

    //Flag that controls the upload score method (this is setted to keep best)
    private static ELeaderboardUploadScoreMethod m_uploadScoreMethod = ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest;


    //Call result that will be set by UpdateScore depending if the OnLeaderBoardUpload result returns true or false.
    private static CallResult<LeaderboardFindResult_t> m_leaderboardFindResult = new CallResult<LeaderboardFindResult_t>();

    private static CallResult<LeaderboardScoreUploaded_t> m_uploadResult = new CallResult<LeaderboardScoreUploaded_t>();

    private static CallResult<LeaderboardScoresDownloaded_t> m_scoresDownloadedResult = new CallResult<LeaderboardScoresDownloaded_t>();

    private void Start()
    {
        FindLeaderboard();
    }

    //this method is used to search the leaderboard by name with a SteamAPICall
    public static void FindLeaderboard()
    {
        //this call finds the leaderboard by name (in this case the nam is already on a variable, but you could use a string normally)
        SteamAPICall_t _steamAPICall = SteamUserStats.FindLeaderboard(m_leaderboardName);


        //---------------------------------------------------------------------------------------------------------------------------
        //The variable "m_leaderboardFindResult" is a call result that needs to be used in conjuction with an "OnLeaderBoardFindResult" Method
        //if the result of the call is true, it'll change the m_steamLeaderboard
        //---------------------------------------------------------------------------------------------------------------------------


        m_leaderboardFindResult.Set(_steamAPICall, OnLeaderBoardFindResult);
    }

    static public void DownloadLeaderboardEntries()
    {
        if (!m_leaderboardInitiated)
            Debug.Log("The leaderboard was not found!");
        else
        {
            SteamAPICall_t _steamAPICall = SteamUserStats.DownloadLeaderboardEntries(m_steamLeaderBoard, ELeaderboardDataRequest.k_ELeaderboardDataRequestGlobal, 1, 5);
            m_scoresDownloadedResult.Set(_steamAPICall, OnLeaderBoardScoresDownloaded);
        }
    }

    static public void UseDownloadedEntries()
    {
        for (int i = 0; i < m_leaderboardCount; i++)
        {
            LeaderboardEntry_t LeaderboardEntry;
            bool ret = SteamUserStats.GetDownloadedLeaderboardEntry(m_leaderboardEntries, i, out LeaderboardEntry, null, 0);
            Debug.Log("Score: " + LeaderboardEntry.m_nScore + " User ID: " + SteamFriends.GetFriendPersonaName(LeaderboardEntry.m_steamIDUser));
        }
    }

    //UpdateScore into the Steam leaderboards
    static public void UpdateScore(int _score)
    {
        //If the leaderboard wasn't initiated, it'll show an error. (this is set by the findLeaderboard method)
        if (!m_leaderboardInitiated)
            Debug.Log("!!!!!!!! The Leaderboard was not found! !!!!!!!");
        else
        {
            SteamAPICall_t _steamAPICall = SteamUserStats.UploadLeaderboardScore(m_steamLeaderBoard, m_uploadScoreMethod, _score, null, 0);
            m_uploadResult.Set(_steamAPICall, OnLeaderBoardUploadResult);
        }       
    }

    static private void OnLeaderBoardFindResult(LeaderboardFindResult_t _callback, bool _IOFailure)
    {
        Debug.Log("STEAM LEADERBOARDS: Found - " + _callback.m_bLeaderboardFound + " leaderboardID - " + _callback.m_hSteamLeaderboard.m_SteamLeaderboard);
        m_steamLeaderBoard = _callback.m_hSteamLeaderboard;
        m_leaderboardInitiated = true;
    }

    //This method is just to check if the upload was successful and permits to debug some things like Failure, if the score was set, etc etc
    static private void OnLeaderBoardUploadResult(LeaderboardScoreUploaded_t _callback, bool _IOFailure)
    {
        Debug.Log("STEAM LEADERBOARDS: failure - " + _IOFailure + " Completed - " + _callback.m_bSuccess + " NewScore: " + _callback.m_nGlobalRankNew + " Score: " + _callback.m_nScore + " HasChanged - " + _callback.m_bScoreChanged);
    }

    //This checks if the leaderboard was successfully downloaded or not and updates the variables that'll be used in conjuction with the SteamAPI Handler
    static private void OnLeaderBoardScoresDownloaded(LeaderboardScoresDownloaded_t _callback, bool _IOFailure)
    {
        m_leaderboardEntries = _callback.m_hSteamLeaderboardEntries;
        m_leaderboardCount = _callback.m_cEntryCount;

        Debug.Log("Leaderboard: " + _callback.m_hSteamLeaderboard + " Entries: " + _callback.m_hSteamLeaderboardEntries + "Count: " + _callback.m_cEntryCount);
    }

    private void Update()
    {
        SteamAPI.RunCallbacks();
       
        if (Input.GetKeyDown(KeyCode.K))
        {

            DownloadLeaderboardEntries();
        }

        if (Input.GetKeyDown(KeyCode.J))
            UseDownloadedEntries();
    }

}
