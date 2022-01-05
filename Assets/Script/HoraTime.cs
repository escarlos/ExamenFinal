using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoraTime : MonoBehaviour
{
    [Tooltip("Tiempo iniciar en Segundos")]
    public int tiempoinicial;
    [Tooltip("Escala del Tiempo del Reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    public Text myText;
    private float TiempoFrameConTiempoScale = 0f;
    private float tiempoMostrarEnSegundos = 0F;
    private float bajarResist;
    void Start()
    {
        //Escala de Tiempo Original
        tiempoMostrarEnSegundos = tiempoinicial;
        ActualizarReloj(tiempoinicial);
        bajarResist = Random.Range(0, 30);
        Debug.Log("Cuantos Segundos se baja resistencia "+bajarResist);
    }

    // Update is called once per frame
    void Update()
    {
        TiempoFrameConTiempoScale = Time.deltaTime * escalaDeTiempo;
        tiempoMostrarEnSegundos += TiempoFrameConTiempoScale;
        ActualizarReloj(tiempoMostrarEnSegundos);
        bajarResist -= Time.deltaTime * escalaDeTiempo;
        DownResistense();
    }
    
    public void ActualizarReloj(float tiempoEnSegundos) {
        int hora = 0;
        int minutos = 0;
        int segundos = 0;
        // int milisegundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        hora = (int) (tiempoEnSegundos / 60) / 60; 
        int cociente =(int) (tiempoEnSegundos / 60);
        minutos = (int) cociente % 60;
        segundos = (int)tiempoEnSegundos % 60;
        //milisegundos = (int)tiempoEnSegundos / 1000;

        textoDelReloj = $"{hora}:{minutos} PM"; 
        myText.text = textoDelReloj;
    }

    public void DownResistense() {
        if (bajarResist < 1) {
            Character.bajarResistencia();
            bajarResist = Random.Range(0, 30);
        }
        
    }
}
