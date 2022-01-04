using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnRock : MonoBehaviour
{
    public GameObject rock;
    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < 6; i++)
        {
            float newX = Random.Range(-21, 48);
            float newZ = Random.Range(-42, 47);
            Instantiate(rock,new Vector3(newX,0.1f,newZ),Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
