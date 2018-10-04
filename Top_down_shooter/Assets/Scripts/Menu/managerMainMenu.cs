using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class managerMainMenu : MonoBehaviour {

	public GameObject canvasOption;
	public GameObject canvasStartGame;
    public GameObject canvasClasses;
	public GameObject canvasDifficulty;
	public GameObject canvasInsane;
	public GameObject canvasInsaneConfirm;
    public GameObject canvasCredits;
	private bool loadScene = false;
	int randomText=0;
	[SerializeField]
	private int scene;
	[SerializeField]
	private Text loadingText;
	[SerializeField]
	private Text tips;
	public GameObject loadingCanvas;

    public Text nameOfClass;
    int index;
    int nextClass;
    int lastClass;

	public void selectOptions(){
		canvasStartGame.SetActive (false);
		canvasOption.SetActive (true);
	}

	public void backOptions(){
		canvasOption.SetActive (false);
		canvasStartGame.SetActive (true);
	}

    public void selectCredits()
    {
        canvasOption.SetActive(false);
        canvasCredits.SetActive(true);
    }
    public void backCredits()
    {
        canvasCredits.SetActive(false);
        canvasOption.SetActive(true);
    }


	public void selectDifficultyGame(){
		canvasClasses.SetActive (true);
		canvasStartGame.SetActive (false);
	}

	public void backSelectDifficultyGame(){
		canvasClasses.SetActive (true);
		canvasDifficulty.SetActive (false);
	}
    public void backFromSelectClass()
    {
        canvasClasses.SetActive(false);
        canvasStartGame.SetActive(true);
    }

	public void insaneDifficultyConfirmation(){
		canvasDifficulty.SetActive (false);
		canvasInsane.SetActive (true);
	}

	public void backInsaneDifficulty(){
		canvasInsane.SetActive (false);
		canvasDifficulty.SetActive (true);
	}

	public void insaneDifficultyConfirmationReally(){
		canvasInsane.SetActive (false);
		canvasInsaneConfirm.SetActive (true);
	}

	public void backInsaneDifficultyConfirmationReally(){
		canvasInsaneConfirm.SetActive (false);
		canvasDifficulty.SetActive (true);
	}

	public void quitGame(){
		Application.Quit();
	}

	public void startSceneNormal(){

		loadingCanvas.SetActive (true);
		canvasDifficulty.SetActive (false);

		if (loadScene == false) {
			randomText = Random.Range (1, 11);

			if (randomText == 1){
				tips.text = "Tips: Destroy the protection hammers before they stack!";
			}
			if (randomText == 2){
				tips.text = "Tips: A carranca is a totem used generally by fishermen to ward off evil spirits. But not this one. It actually shoots evil spirits at you!";
			}
			if (randomText == 3){
				tips.text = "Tips: The lotus shoots at the player's location, but it does have a chance to miss";
			}
			if (randomText == 4){
				tips.text = "Tips: Portals can shoot bomb-like projectiles that cause a lot of area damage!";
			}
			if (randomText == 5){
				tips.text = "Tips: Frozen orbs can shoot a lot projectiles at once, but it does have a lower chance to spawn!";
			}
			if (randomText == 6){
				tips.text = "Tips: Keep moving so you have less chance to get hit";
			}
			if (randomText == 7){
				tips.text = "Tips: You can hide behind crates or pillars to avoid damage";
			}

			if (randomText == 8){
				tips.text = "Tips: Press shift to unleash a vortex that will suck all your enemies bullets";
			}
			if (randomText == 9){
				tips.text = "Tips: Wpower does have a chance to drop from enemies!";
			}
			if (randomText == 10){
				tips.text = "Tips: At 15 Wpower your weapon upgrades to level 2, at 40 WPower your weapon upgrades to level 3";
			}

			scene = 1;
			// ...set the loadScene boolean to true to prevent loading a new scene more than once...
			loadScene = true;

			// ...change the instruction text to read "Loading..."
			loadingText.text = "Loading...";

			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNewScene());

		}

		// If the new scene has started loading...

	}

	void Update(){
		if (loadScene == true) {

			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

		}
	}
	public void startSceneHard(){

		loadingCanvas.SetActive (true);
		canvasDifficulty.SetActive (false);

		if (loadScene == false) {

			if (loadScene == false) {
				randomText = Random.Range (1, 6);

				if (randomText == 1){
					tips.text = "Tips: Hard mode gives more score points for every enemy death, if you want to get into the top 5 hard mode is the way to go";
				}
				if (randomText == 2){
					tips.text = "Tips: Vortexes have a low chance to drop from enemies";
				}
				if (randomText == 3){
					tips.text = "Tips: When Frozen orbs stack together try to use a vortex to escape";
				}
				if (randomText == 4){
					tips.text = "Tips: If you try to hide behind crates in this mode you'll get torn down eventually.";
				}
				if (randomText == 5){
					tips.text = "Tips: Watch the portal's rotation so you can try to predict the projectile's trajectory.";
				}
				if (randomText == 6){
					tips.text = "Tips: Carrancas are pretty cool, aren't they?";
				}

				scene = 2;
				// ...set the loadScene boolean to true to prevent loading a new scene more than once...
				loadScene = true;

				// ...change the instruction text to read "Loading..."
				loadingText.text = "Loading...";

				// ...and start a coroutine that will load the desired scene.
				StartCoroutine(LoadNewScene());

			}

			// If the new scene has started loading...
			if (loadScene == true) {

				// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
				loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

			}

		}
	}

	public void startSceneInsane(){

		loadingCanvas.SetActive (true);
		canvasInsaneConfirm.SetActive (false);

		if (loadScene == false) {
			randomText = Random.Range (1, 8);

			if (randomText == 1){
				tips.text = "Tips: Probably you'll fail at this difficulty.";
			}
			if (randomText == 2){
				tips.text = "Tips: your pc will cry";
			}
			if (randomText == 3){
				tips.text = "Tips: god i wish i had the CPU to run this mode";
			}
			if (randomText == 4){
				tips.text = "Tips: I just build this mode to see if someone really could survive it for more than 1min.";
			}
			if (randomText == 5){
				tips.text = "Tips: Carrancas are pretty cool, aren't they?";
			}
			if (randomText == 6){
				tips.text = "Tips: This map was done in 2 hours";
			}

			if (randomText == 7){
				tips.text = "Tips: I really wonder if someone will get a record from this mode";
			}


			scene = 3;
			// ...set the loadScene boolean to true to prevent loading a new scene more than once...
			loadScene = true;

			// ...change the instruction text to read "Loading..."
			loadingText.text = "Loading... Why are you playing this mode anyway?";

			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNewScene());

		}

		// If the new scene has started loading...
		if (loadScene == true) {

			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

		}
	}

	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene()
    {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(3);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = Application.LoadLevelAsync(scene);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}

	}




}

