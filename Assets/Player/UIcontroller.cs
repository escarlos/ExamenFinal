using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Text namePlayer;
    void Start() {
        namePlayer.text = Character.nameStatic;
        transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().fillAmount = Character.life/100;
    }

    private void Update() {
        transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().fillAmount = sacarPorcentaje(Character.life);
    }

    private float sacarPorcentaje(float ahora) {
        Character.Personaje vidaOriginal = new Character.Personaje();
        return ((100 * ahora) / vidaOriginal.vida)/100;

    }
}
