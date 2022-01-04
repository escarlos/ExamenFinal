using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockLife : MonoBehaviour
{
    public int cantidadRock = 1;

    public void removeRock() {
        if (cantidadRock > 0) { 
            cantidadRock -= 1;
        }
        
    }
}
