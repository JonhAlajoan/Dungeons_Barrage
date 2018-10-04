using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckOwnageClasses : MonoBehaviour {
    public Button[] ButtonsClasses;
    public List<int> isClassOwned = new List<int>();
    int index;
    int testClass;

    public GameObject canvasSelectClasses;
    public GameObject canvasSelectDifficulty;

    // Use this for initialization
    void Start () {
        index = 0;
        isClassOwned.Add(0);
        isClassOwned.Add(1);
        isClassOwned.Add(2);
        isClassOwned.Add(3);
        isClassOwned.Add(4);
        isClassOwned.Add(5);
        isClassOwned.Add(6);
        isClassOwned.Add(7);

        //Load();

        foreach (Button button in ButtonsClasses)
        {
            bool callFunctionCheckIfBought = checkIfBought(index);
            Debug.Log(index);

            if(callFunctionCheckIfBought == true)
            {
                ButtonsClasses[index].interactable = true;
            }

            if (callFunctionCheckIfBought == false)
            {
                ButtonsClasses[index].interactable = false;
            }
            index++;
        }
        index = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
#region selectClasses
    public void SelectMagus()
    {

        SaveGame.Save("ClassSelected", 0);
        canvasSelectClasses.SetActive(false);
        canvasSelectDifficulty.SetActive(true);
    }
    public void SelectShaman()
    {

        SaveGame.Save("ClassSelected", 1);
        canvasSelectClasses.SetActive(false);
        canvasSelectDifficulty.SetActive(true);
    }
    public void SelectEngineer()
    {

        SaveGame.Save("ClassSelected", 2);
        canvasSelectClasses.SetActive(false);
        canvasSelectDifficulty.SetActive(true);
    }
    public void SelectPriest()
    {

        SaveGame.Save("ClassSelected", 3);
        canvasSelectClasses.SetActive(false);
        canvasSelectDifficulty.SetActive(true);
    }
    public void SelectWarlock()
    {
        
        SaveGame.Save("ClassSelected", 4);
        canvasSelectClasses.SetActive(false);
        canvasSelectDifficulty.SetActive(true);
    }
    public void SelectAlchemist()
    {

        SaveGame.Save("ClassSelected", 5);
        canvasSelectClasses.SetActive(false);
        canvasSelectDifficulty.SetActive(true);
    }

    public void SelectLunarKnight()
    {

        SaveGame.Save("ClassSelected", 6);
        canvasSelectClasses.SetActive(false);
        canvasSelectDifficulty.SetActive(true);
    }

    public void SelectSolarKnight()
    {

        SaveGame.Save("ClassSelected", 7);
        canvasSelectClasses.SetActive(false);
        canvasSelectDifficulty.SetActive(true);
    }

    #endregion

    public bool checkIfBought(int indexOfClass)
    {
        if (isClassOwned.Contains(indexOfClass))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private void Load()
    {
        SaveGame.Load("listOfClassesOwned",isClassOwned);
    }
}
