using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLife : MonoBehaviour
{
    public int cantidadRope = 1;

    // Update is called once per frame
    void Update()
    {
        // if (cantidadRope < 1) {
        //     Destroy(gameObject);
        // }
    }

    public void removeRope() {
        if (cantidadRope > 0) { 
            cantidadRope -= 1;
        }
    }
}
