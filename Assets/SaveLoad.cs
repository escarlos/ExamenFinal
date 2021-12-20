using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public Text loadSave;
    void Start()
    {
        LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadPlayer()
    {
        loadSave.text = PlayerPrefs.GetString("name");
    }
}
