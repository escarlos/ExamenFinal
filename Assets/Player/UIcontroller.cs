using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Text namePlayer;
    void Start() {
        namePlayer.text = Character.nameStatic;
        Character.Personaje personajeUi = new Character.Personaje();
        transform.GetChild(0).transform.GetComponent<Image>().fillAmount = personajeUi.vida;
    }
}
