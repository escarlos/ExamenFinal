using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManage : MonoBehaviour {
    
    // Start is called before the first frame update
    void Start() {
        menuCharacterPlayer();
    }

    // Update is called once per frame
    void Update() {
        menuCharacterPlayer();
    }

    private void menuCharacterPlayer() {
        Text vidaCount = transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
        Text resisCount = transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        Text expeCount = transform.GetChild(3).transform.GetChild(0).GetComponent<Text>();
        Text levelCount = transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
        Text nombre = transform.GetChild(5).transform.GetChild(0).GetComponent<Text>();
        vidaCount.text = Character.life.ToString();
        resisCount.text = Character.resistance.ToString();
        expeCount.text = Character.experiencia.ToString();
        levelCount.text = Character.nivel.ToString();
        nombre.text = Character.nameStatic;
    }

}
