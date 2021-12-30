using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeLife : MonoBehaviour
{

    public int cantidadRama = 1;
    public int cantidadHoja = 1;
    public bool typeArbol;

    public void removeBranch() {
        if (cantidadRama > 0) { 
            cantidadRama -= 1;
        }
        
    }

    public void removeLeaf() {
        if (cantidadHoja > 0) {
           cantidadHoja -= 1; 
        }
        
    }
    
}
