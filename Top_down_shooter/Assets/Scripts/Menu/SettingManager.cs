using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using BayatGames.SaveGameFree;

public class SettingManager : MonoBehaviour {
	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Slider musicVolumeSlider;
	public Button applyButton;

	public AudioSource musicSource;
	public Resolution[] resolutions;
	public gameSettings gameSettings;

    public Toggle AntiAliasingToggle;
    public Toggle BloomToggle;
    public Toggle AmbientOcclusionToggle;

    public GameObject canvasMenu;
    public GameObject canvasOptions;

    bool antiAliasing;
    bool bloom;
    bool ambientOcclusion;

	bool firstTimeLoaded;

	void OnEnable()
	{
        
        gameSettings = new gameSettings ();
		fullscreenToggle.onValueChanged.AddListener (delegate {OnFullScreenToggle();});
        resolutionDropdown.onValueChanged.AddListener (delegate {OnResolutionChange();});
		textureQualityDropdown.onValueChanged.AddListener (delegate {OnTextureQualityChange();});
		musicVolumeSlider.onValueChanged.AddListener (delegate {OnMusicVolumeChange();});
		applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });
		resolutions = Screen.resolutions;
		foreach (Resolution resolution in resolutions) {
			resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
		}
        LoadSettings();
        Time.timeScale = 1.0f;

    }

    public void OnAntiAliasingToggle()
    {
        antiAliasing = AntiAliasingToggle.isOn;
    }

    public void OnBloomToggle()
    {
        bloom = BloomToggle.isOn;
    }

    public void OnAmbientOcclusion()
    {
        ambientOcclusion = AmbientOcclusionToggle.isOn;
    }

	public void OnFullScreenToggle(){
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}

	public void OnResolutionChange(){
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen);
	}

	public void OnTextureQualityChange(){
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
		gameSettings.resolutionIndex = resolutionDropdown.value;
	}

	public void OnMusicVolumeChange(){
		musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
	}

	public void SaveSettings(){
		string jsonData = JsonUtility.ToJson (gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gamesettings.json", jsonData);
        SaveGame.Save("antiAliasing", antiAliasing);
        Debug.Log("Saving antialiasing as: " + antiAliasing);

        SaveGame.Save("bloom", bloom);
        Debug.Log("Saving bloom as: " + bloom);

        SaveGame.Save("ambientOcclusion", ambientOcclusion);
        Debug.Log("Saving ambientOcclusoin as: " + ambientOcclusion);
    }

	public void OnApplyButtonClick(){
		SaveSettings ();
        canvasOptions.SetActive(false);
        canvasMenu.SetActive(true);

	}
	public void LoadSettings(){

		if(firstTimeLoaded)
		{
			bloom = true;
			antiAliasing = true;
			ambientOcclusion = true;
			firstTimeLoaded = false;
			SaveGame.Save("firstTimeLoaded", firstTimeLoaded);
		}

		else
		{
			AntiAliasingToggle.isOn = SaveGame.Load("antiAliasing", antiAliasing);
			Debug.Log("Carregado Antialiasing: " + AntiAliasingToggle.isOn);

			BloomToggle.isOn = SaveGame.Load("bloom", bloom);
			Debug.Log("Carregado Bloom: " + BloomToggle.isOn);

			AmbientOcclusionToggle.isOn = SaveGame.Load("ambientOcclusion", ambientOcclusion);
			Debug.Log("Carregado Ambient OCc " + AmbientOcclusionToggle.isOn);

			gameSettings = JsonUtility.FromJson<gameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
			musicVolumeSlider.value = gameSettings.musicVolume;
			textureQualityDropdown.value = gameSettings.textureQuality;
			resolutionDropdown.value = gameSettings.resolutionIndex;
			fullscreenToggle.isOn = gameSettings.fullscreen;
			Screen.fullScreen = gameSettings.fullscreen;


			resolutionDropdown.RefreshShownValue();

		}


	}
    

}
