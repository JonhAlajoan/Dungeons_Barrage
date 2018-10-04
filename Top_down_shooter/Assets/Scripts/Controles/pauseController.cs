using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
public class pauseController : MonoBehaviour
{

	public GameObject canvasComum;
	public GameObject canvasPause;
	public GameObject canvasTutorial;
	public int playerClass;
    GameObject objectPlayerClass;
    GameObject objectPlayer;

    ClassesPlayer playerClassScript;
    public Text textMisc;
    public Text textSpecial;
    public Text classType;

	int flagCursor;
	public PostProcessingProfile cameraBlur;

    private void Start()
    {
        objectPlayerClass = GameObject.FindWithTag("Manager");
        objectPlayer = GameObject.FindWithTag("PlayerHP");
        playerClassScript = objectPlayer.GetComponent<ClassesPlayer>();

    }

    void update(){
		if (canvasTutorial || canvasPause) {
			cameraBlur.depthOfField.enabled = true;
		} else {
			cameraBlur.depthOfField.enabled = false;
		}
	}

	public void resumeGame(){
		Time.timeScale = 1.0f;
		Cursor.visible = false;

        playerClassScript.unpauseGame(1);
        
		
		cameraBlur.depthOfField.enabled = false;
		canvasPause.SetActive (false);
		canvasComum.SetActive (true);
	} 

	public void returnMainMenu(){
		canvasComum.SetActive (true);
		canvasPause.SetActive (false);
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("menuTeste");
	}

    public void restartNormal()
    {
        canvasComum.SetActive(true);
        canvasPause.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("normal");
    }

    public void restartHard()
    {
        canvasComum.SetActive(true);
        canvasPause.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("hard");
    }

    public void restartInsane()
    {
        canvasComum.SetActive(true);
        canvasPause.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("insane");
    }
	public void tutorialSelect(){
		canvasTutorial.SetActive (true);
		canvasPause.SetActive (false);
	}
	public void returnTutorial(){
		canvasTutorial.SetActive (false);
		canvasPause.SetActive (true);
	}
}
