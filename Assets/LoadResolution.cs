using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        Dropdown listDrop =transform.GetComponent<Dropdown>();
        
        listDrop.options.Clear();
        string screenScope = Screen.safeArea.height +"x"+Screen.safeArea.width;
        
        List<string> items = new List<string>();
        
        foreach (var resolution in Screen.resolutions) {
            items.Add(resolution.ToString());
        }

        foreach (var res in items) {
            listDrop.options.Add(new Dropdown.OptionData() {text = res});
        }
    }

}
