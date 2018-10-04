using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class ManagerClasses : MonoBehaviour {

    public int ClassBeingUsed;
    public Transform muzzle;
    
    public Camera cameraScene;

    public PostProcessingProfile PostProcessingScene;

    bool isBloomEnabled;
    bool isAmbientOcclusionEnabled;
    bool isAntiAliasingEnabled;

    public GameObject TextMesh;

    // Use this for initialization
    private void Awake()
    {
        Load();        
        checkClassBeingUsed();
              
    }

    void Start () {

        cameraScene = Camera.main;
        PostProcessingScene = cameraScene.GetComponent<PostProcessingBehaviour>().profile;
        VFXSettings();

    }
  
    public void checkClassBeingUsed()
    {
        switch (ClassBeingUsed)
        {
            case 0:
                TrashMan.spawn("player", muzzle.transform.position, muzzle.transform.rotation);
                break;
            case 1:
                TrashMan.spawn("player_shaman_2", muzzle.transform.position, muzzle.transform.rotation);
                break;
            case 2:
                TrashMan.spawn("player_Engineer", muzzle.transform.position, muzzle.transform.rotation);
                break;
            case 3:
                TrashMan.spawn("player_Priest", muzzle.transform.position, muzzle.transform.rotation);
                break;
            case 4:
                TrashMan.spawn("player_Witch", muzzle.transform.position, muzzle.transform.rotation);
                break;
            case 5:
                TrashMan.spawn("player_Alchemist", muzzle.transform.position, muzzle.transform.rotation);
                break;
            case 6:
                TrashMan.spawn("player_LunarKnight", muzzle.transform.position, muzzle.transform.rotation);
                break;
            case 7:
                TrashMan.spawn("player_SolarKnight", muzzle.transform.position, muzzle.transform.rotation);
                break;
        }
    }

    public void VFXSettings()
    {
        PostProcessingScene.antialiasing.enabled = isAntiAliasingEnabled;
        PostProcessingScene.ambientOcclusion.enabled = isAmbientOcclusionEnabled;
        PostProcessingScene.bloom.enabled = isBloomEnabled;
    }

    void Load()
    {
        ClassBeingUsed = SaveGame.Load("ClassSelected",ClassBeingUsed);
        isAntiAliasingEnabled = SaveGame.Load("antiAliasing",isAntiAliasingEnabled);
        isBloomEnabled = SaveGame.Load("bloom", isBloomEnabled);
        isAmbientOcclusionEnabled = SaveGame.Load("ambientOcclusion", isAmbientOcclusionEnabled);
    }
	
}
