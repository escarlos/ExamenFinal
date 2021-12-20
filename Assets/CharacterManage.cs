using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManage : MonoBehaviour {
    
    public Character.Personaje personajeStats = new Character.Personaje();
    // Start is called before the first frame update
    void Start()
    {
        Text vidaCount = transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
        Text resisCount = transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        Text expeCount = transform.GetChild(3).transform.GetChild(0).GetComponent<Text>();
        Text levelCount = transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
        Text nombre = transform.GetChild(5).transform.GetChild(0).GetComponent<Text>();
        vidaCount.text = personajeStats.vida.ToString();
        resisCount.text = personajeStats.resistencia.ToString();
        expeCount.text = personajeStats.experiencia.ToString();
        levelCount.text = personajeStats.level.ToString();
        personajeStats.setNombre(Character.nameStatic);
        nombre.text = personajeStats.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
