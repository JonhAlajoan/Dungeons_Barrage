using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;
public class SpawnController : MonoBehaviour {

	public GameObject[] spawners;


	void Start(){
		foreach (GameObject spawner in spawners)
		{
			spawner.SetActive (true);
		}
		
	}

	public void reiniciaGameNormal()
	{
		SceneManager.LoadScene ("normal");
	}

	public void reiniciaGameHard()
	{

		SceneManager.LoadScene ("hard");
	}

	public void reiniciaGameInsane()
	{

		SceneManager.LoadScene ("insane");
	}

	public void mainMenu()
	{
		SceneManager.LoadScene ("menuTeste");
	}
}
