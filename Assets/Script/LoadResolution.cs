using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Dropdown listDrop =transform.GetComponent<Dropdown>();
        string jsonString = PlayerPrefs.GetString("Configuration");
        ConfigureScript.ConfigurationSave loadConfigure = JsonUtility.FromJson<ConfigureScript.ConfigurationSave>(jsonString);
        int i = 0;
        int defaultScreen = 0;
        string screenScope = Screen.currentResolution.height +"x" +Screen.currentResolution.width;
        listDrop.options.Clear();
        List<string> items = new List<string>();
        
        foreach (var resolution in Screen.resolutions) {
            if (resolution.height+"x" +resolution.width == screenScope) {
                defaultScreen = i;
            }
            items.Add(resolution.ToString());
            i++;
        }

        foreach (var res in items) {
            listDrop.options.Add(new Dropdown.OptionData() {text = res});
        }

        if (loadConfigure != null) {
            listDrop.value = loadConfigure.resolutionSelected;
        }else {
            listDrop.value = defaultScreen;
        }
    }

}
