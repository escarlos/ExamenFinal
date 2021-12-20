using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour {
    public static String nameStatic;

    
    [Serializable]
    public class Personaje {
        public String name;
        public float vida = 100;
        public float resistencia = 100;
        public float experiencia = 1;
        public int level = 1;
        public Vector3 ubicacion;

        public void DamageLife(float damageRecibe) {
            vida -= damageRecibe;
        }

        public void setNombre(String inName) {
            name = inName;
        }

        public void setUbicacion(Vector3 gps) {
            ubicacion = gps;
        }
    }
}
