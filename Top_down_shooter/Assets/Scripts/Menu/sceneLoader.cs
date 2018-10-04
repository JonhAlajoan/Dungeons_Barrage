using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sceneLoader : MonoBehaviour {

	private bool loadScene = false;
	int randomText=0;
	[SerializeField]
	private int scene;
	[SerializeField]
	private Text loadingText;
	[SerializeField]
	private Text tips;
	public GameObject loadingCanvas;


	public void startSceneNormal(){
		
		loadingCanvas.SetActive (true);


		if (loadScene == false) {
			randomText = Random.Range (1, 6);

			if (randomText == 1){
				tips.text = "Tips: Protection hammers can be a nuisance. Just destroy them before they get in your way (they're worth 20 points anyway)";
			}
			if (randomText == 2){
				tips.text = "Tips: A carranca is a totem used generally by fishermen to ward off evil spirits. But not this one. It actually shoots evil spirits at you!";
			}
			if (randomText == 3){
				tips.text = "Tips: The lotus shoots at the player's location, but it does have a chance to miss";
			}
			if (randomText == 4){
				tips.text = "Tips: Portals used to shoot projectiles that could one-shot the player but it was actually pretty unfair. (They still cause a lot of damage)";
			}
			if (randomText == 5){
				tips.text = "Tips: Frozen orbs can shoot a lot projectiles at once, but only appears late in the game. Take care.";
			}
			if (randomText == 6){
				tips.text = "Tips: Keep moving and nobody gets hurt! (Except if you're in the range of a frozen orb)";
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
		if (loadScene == true) {

			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

		}
	}

	public void startSceneHard(){

		loadingCanvas.SetActive (true);

		if (loadScene == false) {
			if (loadScene == false) {
				randomText = Random.Range (1, 6);

				if (randomText == 1){
					tips.text = "Tips: Protection hammers can be a nuisance. Just destroy them before they get in your way (they're worth 20 points anyway)";
				}
				if (randomText == 2){
					tips.text = "Tips: A carranca is a totem used generally by fishermen to ward off evil spirits. But not this one. It actually shoots evil spirits at you!";
				}
				if (randomText == 3){
					tips.text = "Tips: The lotus shoots at the player's location, but it does have a chance to miss";
				}
				if (randomText == 4){
					tips.text = "Tips: Portals used to shoot projectiles that could one-shot the player but it was actually pretty unfair. (They still cause a lot of damage)";
				}
				if (randomText == 5){
					tips.text = "Tips: Frozen orbs can shoot a lot projectiles at once, but only appears late in the game. Take care.";
				}
				if (randomText == 6){
					tips.text = "Tips: Keep moving and nobody gets hurt! (Except if you're in the range of a frozen orb)";
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

		if (loadScene == false) {
			randomText = Random.Range (1, 6);

			if (randomText == 1){
				tips.text = "Tips: Protection hammers can be a nuisance. Just destroy them before they get in your way (they're worth 20 points anyway)";
			}
			if (randomText == 2){
				tips.text = "Tips: A carranca is a totem used generally by fishermen to ward off evil spirits. But not this one. It actually shoots evil spirits at you!";
			}
			if (randomText == 3){
				tips.text = "Tips: The lotus shoots at the player's location, but it does have a chance to miss";
			}
			if (randomText == 4){
				tips.text = "Tips: Portals used to shoot projectiles that could one-shot the player but it was actually pretty unfair. (They still cause a lot of damage)";
			}
			if (randomText == 5){
				tips.text = "Tips: Frozen orbs can shoot a lot projectiles at once, but only appears late in the game. Take care.";
			}
			if (randomText == 6){
				tips.text = "Tips: Keep moving and nobody gets hurt! (Except if you're in the range of a frozen orb)";
			}

			scene = 3;
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

	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {

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