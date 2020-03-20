using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.UI;
using System.Threading;

public class LeaderboardCell
{
    public Sprite playerImage;
    public string playerName;
    public int playerScore;

    public LeaderboardCell(Sprite _playerImage, string _playerName, int _playerScore)
    {
        playerImage = _playerImage;
        playerName = _playerName;
        playerScore = _playerScore;
    }
}

public class SteamLeaderboard : MonoBehaviour
{
    //Leaderboard name, can be put directly into the "SteamUserStats.FindLeaderBoard"
    private const string m_leaderboardName = "db_teste_board";

    //Quantity of entries found on a given leaderboard
    private static int m_leaderboardCount;

    //Steam leaderboard got by the 
    private static SteamLeaderboard_t m_steamLeaderBoard;

    private static SteamLeaderboardEntries_t m_leaderboardEntries;

    private static List<LeaderboardCell> leaderboardPLayersList = new List<LeaderboardCell>();

    private static List<GameObject> leaderboardCellList = new List<GameObject>();

    [SerializeField]
    private Transform m_Leaderboardtarget;

    [SerializeField]
    private GameObject m_leaderboardPrefab;

    [SerializeField]
    private float m_distanceBetweenCells;


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
            LeaderboardEntry_t _LeaderboardEntry;
            Sprite _playerImage;

            bool ret = SteamUserStats.GetDownloadedLeaderboardEntry(m_leaderboardEntries, i, out _LeaderboardEntry, null, 0);
            Debug.Log("Score: " + _LeaderboardEntry.m_nScore + " User ID: " + SteamFriends.GetFriendPersonaName(_LeaderboardEntry.m_steamIDUser));

            _playerImage = FetchAvatar(_LeaderboardEntry.m_steamIDUser,i);

            leaderboardPLayersList.Insert(i, new LeaderboardCell(_playerImage, SteamFriends.GetFriendPersonaName(_LeaderboardEntry.m_steamIDUser), _LeaderboardEntry.m_nScore));
          
        }
    }


    public void InstantiateNewLeaderboardCell()
    {

        for (int i = 0; i < leaderboardPLayersList.Count; i++)
        {
            Vector2 _cellPosition;
            GameObject _instantiatedCell = Instantiate(m_leaderboardPrefab);
            _instantiatedCell.transform.parent = m_Leaderboardtarget.transform;

            if (leaderboardCellList.Count > 0)
                _cellPosition = new Vector2(leaderboardCellList[i - 1].transform.localPosition.x,
                    leaderboardCellList[i - 1].transform.localPosition.y - m_distanceBetweenCells);
            else
                _cellPosition = new Vector2(0, 0);

            _instantiatedCell.transform.localPosition = _cellPosition;

            leaderboardCellList.Insert(i, _instantiatedCell);

            Image _playerImage = leaderboardCellList[i].transform.GetComponentInChildren<Image>();
            Text[] _playerTexts = leaderboardCellList[i].transform.GetComponentsInChildren<Text>();

            _playerImage.sprite = leaderboardPLayersList[i].playerImage;
            _playerTexts[0].text = leaderboardPLayersList[i].playerName;
            _playerTexts[1].text = leaderboardPLayersList[i].playerScore.ToString();


            Debug.Log("------------------------------------------------------" + "\n" +
                      "Name: " + leaderboardPLayersList[i].playerName + "\n" +
                      "Score: " + leaderboardPLayersList[i].playerScore + "\n" +
                       "Image: " + leaderboardPLayersList[i].playerImage + "\n" +
                      "-------------------------------------------------------");
            /*
            playerImg.sprite = leaderboardPLayersList[i].playerImage;
            ScoreText.text = leaderboardPLayersList[i].playerScore.ToString();
            NameText.text = leaderboardPLayersList[i].playerName;*/
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

    

    public static Sprite FetchAvatar(CSteamID _steamID, int _index)
    {
        int _avatarInt;
        uint _width, _height;
        Texture2D _downloadedAvatar;
        Rect _rect = new Rect(0, 0, 184, 184);
        Vector2 _pivot = new Vector2(0.5f, 0.5f);

        _avatarInt = SteamFriends.GetLargeFriendAvatar(_steamID);

        while (_avatarInt == -1)
        {
            Debug.Log("avatar not found");
        }

        if(_avatarInt > 0)
        {
            SteamUtils.GetImageSize(_avatarInt, out _width, out _height);

            if(_width > 0 && _height > 0)
            {
                byte[] _avatarStream = new byte[4 * (int)_width * (int)_height];

                SteamUtils.GetImageRGBA(_avatarInt, _avatarStream, 4 * (int)_width * (int)_height);

                _downloadedAvatar = new Texture2D((int)_width, (int)_height, TextureFormat.RGBA32, false);
                _downloadedAvatar.LoadRawTextureData(_avatarStream);
                _downloadedAvatar.Apply();

                return(Sprite.Create(_downloadedAvatar, _rect, _pivot));
            }
        }

        return null;
    }


    #region callback methods
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
    #endregion

    private void Update()
    {
        SteamAPI.RunCallbacks();
       
        if (Input.GetKeyDown(KeyCode.K))
        {
            DownloadLeaderboardEntries();
        }

        if (Input.GetKeyDown(KeyCode.J))
            UseDownloadedEntries();

        if (Input.GetKeyDown(KeyCode.C))
            InstantiateNewLeaderboardCell();
    }

}
