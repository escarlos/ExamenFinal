using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigureScript : MonoBehaviour
{
    public GameObject childObjectConfigure;
    public AudioSource soundInstance;
    private GameObject child;
    void Start() {
            for (int i = 0; i < childObjectConfigure.transform.childCount ; i++) {
                if(childObjectConfigure.transform.GetChild(i).name == "SoundGroup") {
                    child = childObjectConfigure.transform.GetChild(i).gameObject;
                    Slider componentSound = child.transform.GetChild(1).GetComponent<Slider>();
                    componentSound.value = soundInstance.volume;
                }
            }
    }
    
    [Serializable]
    public class ConfigurationSave {
        public float soundVolume;
        public float height;
        public float width;
        public bool isFullscrn;
    }
}
