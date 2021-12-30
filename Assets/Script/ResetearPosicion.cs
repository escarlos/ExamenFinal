using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetearPosicion : MonoBehaviour
{
   public GameObject spawn;
   private void OnTriggerEnter(Collider other) {
      if (other.tag == "Player") {
         Character.DamageLife(10);
         StartCoroutine(mostrar("", 10));
         other.transform.position = spawn.transform.position;

      }
   }
   IEnumerator mostrar(string item, float cantidad) {
      GameObject.FindWithTag("UI").transform.GetChild(3).GetComponent<Text>().text = $"Has recibido {cantidad} de daño";
      yield return new WaitForSecondsRealtime(1);
      GameObject.FindWithTag("UI").transform.GetChild(3).GetComponent<Text>().text = "";
   }
}
