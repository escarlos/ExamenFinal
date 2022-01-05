using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {
    public static Personaje player = new Personaje();
    public static String nameStatic;
    public static float life = player.vida;
    public static float resistance = player.resistencia;
    public static float experiencia = player.experiencia;
    public static int nivel = player.level;
    public static float posX = player.posX;
    public static float posY = player.posY;
    public static float posZ = player.posZ;
    public static List<string> nombreItem = player.nombreItem;
    public static List<int> cantidadItem = player.cantidadItem;


    public static void DamageLife(float damageRecibe) {
        life -= damageRecibe;
    } 
    
    public static void addInventory(string key, int value) {
        int encontro = 3;
        if (nombreItem.Count == 0) {
           nombreItem.Add(key);
           cantidadItem.Add(value);
        }else {
            for (int i = 0; i < nombreItem.Count; i++) {
                if (nombreItem[i].Equals(key)) {
                    cantidadItem[i] += value;
                    encontro = 1;
                    Debug.Log("encontro "+encontro );
                    break;
                }else {
                    encontro = 0;
                }
            }
            if (encontro == 0) {
                Debug.Log("encontro "+encontro );
                nombreItem.Add(key);
                cantidadItem.Add(value);
            }
        }
        Debug.Log("cantidad del array "+nombreItem.Count );
    }

    public static int getcantidadItem(string key) {
        int idItem = 0;
        for (int i = 0; i < nombreItem.Count; i++) {
            if (nombreItem[i] == key) {
                idItem = i;
            }
        }
        return idItem;
    }

    public static string lookInventory() {
        string inventario = "";
        if (nombreItem !=null) {
            for (int i = 0; i < nombreItem.Count; i++) { 
                inventario += $"El item {nombreItem[i]} tienes : ";
                inventario += $"{cantidadItem[i]} \n";
            }
        
        }
        return inventario;
    }

    public static void saveUbicacion(float gpsX,float gpsY,float gpsZ) {
        posX = gpsX;
        posY = gpsY;
        posZ = gpsZ;
    }

    public static void aumentarExperiencia()
    {
        experiencia += 100;
    }

    public static void bajarResistencia() {
        resistance -= 5;
    }
    
    
    [Serializable]
    public class Personaje {
        public String name;
        public float vida = 100;
        public float resistencia = 100;
        public float experiencia = 1;
        public int level = 1;
        public float posX;
        public float posY;
        public float posZ;
        public List<string> nombreItem;
        public List<int> cantidadItem;
    }
    
    
}
