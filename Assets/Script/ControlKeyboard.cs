using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlKeyboard : MonoBehaviour
{
    public bool prestE = false;

    public Collider colision;
    public Collider colision2;
    public Collider colision3;
    // Start is called before the first frame update
    void Start()
    {
        Character.nombreItem = new List<string>();
        Character.cantidadItem = new List<int>();
    }

    // Update is called once per frame
    void Update() {
        if( Input.GetKeyDown( KeyCode.E ) && prestE){
            if (colision)
            {
                var hideFlags = colision.tag;
                switch (hideFlags)
                {
                    case "Tree":
                        if (colision.GetComponent<TreeLife>().typeArbol) {
                            if (colision.GetComponent<TreeLife>().cantidadHoja > 0) {
                                Character.addInventory("Hoja", 1);
                                colision.GetComponent<TreeLife>().removeLeaf();
                                StartCoroutine(agregarItem("Hoja", 1));
                                Debug.Log("mandamos a llamar desde hoja");
                            }
                        }
                        if (colision.GetComponent<TreeLife>().typeArbol == false) {
                            if (colision.GetComponent<TreeLife>().cantidadRama > 0) {
                                Character.addInventory("Rama", 1);
                                colision.GetComponent<TreeLife>().removeBranch();
                                StartCoroutine(agregarItem("Rama", 1));
                                Debug.Log("mandamos a llamar desde rama");
                            }
                        }
                        break;
                    case "Rope":
                        if (colision.GetComponent<RopeLife>().cantidadRope > 0) {
                                Character.addInventory("Cuerda", 1);
                                colision.GetComponent<RopeLife>().removeRope();
                                StartCoroutine(agregarItem("Cuerda", 1));
                                Debug.Log("mandamos a llamar desde Cuerda");
                        }
                        break;
                }
            }
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Tree") || other.CompareTag("Rope")) {
            GameObject.FindWithTag("UI").transform.GetChild(2).gameObject.SetActive(true);
            prestE = true;
            if (other.CompareTag("Tree")) { 
                colision = other;
            }
            if (other.CompareTag("Rope")) {
                colision = other;
            }
            if (other.CompareTag("Rock")) {
                colision = other;
            }
           
            Debug.Log(Input.GetKeyDown( KeyCode.E ));
        }
       
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Tree") || other.CompareTag("Rope") ) {
            GameObject.FindWithTag("UI").transform.GetChild(2).gameObject.SetActive(false);
            prestE = false;
            colision = null;
            colision2 = null;
            colision3 = null;
        }
    }

    IEnumerator agregarItem(string item, int cantidad) {
        GameObject.FindWithTag("UI").transform.GetChild(3).GetComponent<Text>().text = $"Has recogido {cantidad} {item}";
        yield return new WaitForSecondsRealtime(1);
        GameObject.FindWithTag("UI").transform.GetChild(3).GetComponent<Text>().text = "";
    }
}
