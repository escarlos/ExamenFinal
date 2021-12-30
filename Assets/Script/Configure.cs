using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using Toggle = UnityEngine.UI.Toggle;

public class Configure : MonoBehaviour
{
    public GameObject menu;
    private List<GameObject> menuList;
    public InputField namePersonaje;
    public Dropdown listResolution;
    public Toggle fullScreenTgl;
    public Slider sliderSoundBackground;
    public AudioSource soundBackground;
    public Text responseConfiguration;
    private int saveWidth;
    private int saveHeight;
    private bool fullScr;

    private void Start() {
        fullScr = fullScreenTgl.isOn;
        ConfigureLoad();
        if (menu != null) {
            menuList = new List<GameObject>();
            Scene sceneScope = SceneManager.GetActiveScene();
            if (sceneScope.name == "PlayGame") {
                menuList.Add(menu.transform.GetChild(2).gameObject); 
                menuList.Add(menu.transform.GetChild(3).gameObject);
                menuList.Add(menu.transform.GetChild(4).gameObject);
            }else {
                menuList.Add(menu.transform.GetChild(0).gameObject); 
                menuList.Add(menu.transform.GetChild(1).gameObject);
                menuList.Add(menu.transform.GetChild(2).gameObject);
                menuList.Add(menu.transform.GetChild(3).gameObject);
            }
        }
    }

    public void ActivateNewGame() {
        menu.transform.GetChild(2).gameObject.SetActive(true);
        EnableMenu(false,1);
        EnableMenu(false,2);
    }
    
    public void ActivateLoadGame() {
        menu.transform.GetChild(3).gameObject.SetActive(true);
        EnableMenu(false,0);
        EnableMenu(false,2);
    }
    
    public void ActivateConfiguration() {
        menu.transform.GetChild(4).gameObject.SetActive(true);
        EnableMenu(false,0);
        EnableMenu(false,1);
    }

    private void EnableMenu(bool state,int id) {
        menuList[id].gameObject.SetActive(state);
    }

    public void CreatePlayer() {
        Character.nameStatic = namePersonaje.text;
        SceneManager.LoadScene(1);
    }

    public void ChangeResolution() {
        int height = Screen.resolutions[listResolution.value].height;
        int width = Screen.resolutions[listResolution.value].width;
        saveWidth = width;
        saveHeight = height;
        Screen.SetResolution(width,height,fullScr);
    }

    public void CloseTab() {
        for (int i = 0; i < menuList.Count; i++) {
            if (menuList[i].activeSelf) {
                menuList[i].SetActive(false);
                if (menuList[i].name == "ConfigurationMenu") {
                    ConfigureLoad();
                }
            }
        }
    }

    public void OpenCharacter() {
        menu.transform.GetChild(0).gameObject.SetActive(true);
        EnableMenu(false,1);
        EnableMenu(false,2);
        EnableMenu(false,3);
    }
    
    public void OpenQuest() {
        menu.transform.GetChild(1).gameObject.SetActive(true);
        EnableMenu(false,0);
        EnableMenu(false,2);
        EnableMenu(false,3);
    }
    
    public void OpenConfigure() {
        menu.transform.GetChild(2).gameObject.SetActive(true);
        EnableMenu(false,0);
        EnableMenu(false,1);
        EnableMenu(false,3);
    }
    public void OpenBag() {
        menu.transform.GetChild(3).gameObject.SetActive(true);
        EnableMenu(false,0);
        EnableMenu(false,1);
        EnableMenu(false,2);
    }

    public void ConfigureSoundController() {
        soundBackground.volume = sliderSoundBackground.value;
    }

    public void SetFullScreen() {
        bool isbool = fullScreenTgl.isOn;
        fullScr = isbool;
        Screen.fullScreen = isbool;
    }

    public void SaveConfiguration() {
        ConfigureScript.ConfigurationSave configureSave = new ConfigureScript.ConfigurationSave();
        configureSave.soundVolume = sliderSoundBackground.value;
        if (saveHeight != 0 && saveWidth != 0) {
          configureSave.height = saveHeight;
          configureSave.width = saveWidth;  
        }else {
            configureSave.height = Screen.safeArea.height;
            configureSave.width = Screen.safeArea.width; 
        }
        configureSave.resolutionSelected = listResolution.value;
        configureSave.isFullscrn = fullScr;
        PlayerPrefs.SetString("Configuration",JsonUtility.ToJson(configureSave));
        StartCoroutine(CooldownResponseText(1f));
        

    }

    public void CambiarEscena() {
        SceneManager.LoadScene(2);
    }
    public void ExitGame() {
        Application.Quit();
    }

    private void ConfigureLoad() {
        if (PlayerPrefs.HasKey("Configuration")) {
            string jsonString = PlayerPrefs.GetString("Configuration");
            ConfigureScript.ConfigurationSave loadConfigure = JsonUtility.FromJson<ConfigureScript.ConfigurationSave>(jsonString);
            soundBackground.volume = loadConfigure.soundVolume;
            fullScreenTgl.isOn = loadConfigure.isFullscrn;
            listResolution.value = loadConfigure.resolutionSelected;
            sliderSoundBackground.value = loadConfigure.soundVolume;
            Screen.SetResolution((int) loadConfigure.width,(int)loadConfigure.height,loadConfigure.isFullscrn);
        }
    }

    IEnumerator CooldownResponseText(float time) {
        responseConfiguration.text = "Guardado con exito";
        yield return new WaitForSeconds(time);
        responseConfiguration.text = "";
    }
}
