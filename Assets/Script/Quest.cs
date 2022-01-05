using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{

    public Text objetivoQuest;
    public Text rewardQuest;
    public int scene;

    [Serializable]
    public struct Questo {
        public string nombreQuest;
        public string objetivoQuest;
        public string reward;
        public int maximoObjetos;
        public ObjetosQuest itemQuest;
        public enum ObjetosQuest {
            Rama,
            Hoja,
            Cuerda,
            Roca
        }

        public List<int> cantidadObjtenida;
    }

    private Questo.ObjetosQuest listaObjetos;

    public List<Questo> quests = new List<Questo>();

    private void Start()
    {
        addQuest();
        for (int i = 0; i < quests.Count; i++) {
            objetivoQuest.text = quests[scene].objetivoQuest;
            rewardQuest.text = quests[scene].reward;
        }

    }

    private void Update() {
        updateQuest();
        completeQuest();
    }

    public void addQuest() {
        Questo mision1 = new Questo();
        if (SceneManager.GetActiveScene().name == "Floor01") {
            Debug.Log("Estamos en scene 1");
            mision1.nombreQuest = "Mision 1";
            mision1.maximoObjetos = 3;
            mision1.cantidadObjtenida = new List<int>();
            for (int i = 0; i < Enum.GetValues(typeof(Questo.ObjetosQuest)).Length; i++) {
                mision1.cantidadObjtenida.Add(0);
            }
            mision1.objetivoQuest = $"Encontrar objetos que permitan ver en la noche, se debe encontrar al menos {mision1.maximoObjetos} de los siguientes objetos: \n" +
                                    $"{Questo.ObjetosQuest.Rama} : {mision1.cantidadObjtenida[0]} / {mision1.maximoObjetos} , \n" +
                                    $"{Questo.ObjetosQuest.Cuerda} : {mision1.cantidadObjtenida[1]} / {mision1.maximoObjetos} , \n" +
                                    $"{Questo.ObjetosQuest.Hoja} : {mision1.cantidadObjtenida[2]} / {mision1.maximoObjetos} \n";
            mision1.reward = "Experiencia ganada 100, pasar a la siguiente fase, sobrevivir un dia mas."; 
        }else if(SceneManager.GetActiveScene().name == "Floor02"){
            Debug.Log("Estamos en scene 2");
            mision1.nombreQuest = "Mision 2";
            mision1.maximoObjetos = 3;
            mision1.cantidadObjtenida = new List<int>();
            for (int i = 0; i < Enum.GetValues(typeof(Questo.ObjetosQuest)).Length; i++) {
                mision1.cantidadObjtenida.Add(0);
            }
            mision1.objetivoQuest = $"Encontrar objetos que permitan ver en la noche, se debe encontrar al menos {mision1.maximoObjetos} de los siguientes objetos: \n" +
                                    $"{Questo.ObjetosQuest.Rama} : {mision1.cantidadObjtenida[0]} / {mision1.maximoObjetos} , \n" +
                                    $"{Questo.ObjetosQuest.Roca} : {mision1.cantidadObjtenida[3]} / {mision1.maximoObjetos} , \n" +
                                    $"{Questo.ObjetosQuest.Hoja} : {mision1.cantidadObjtenida[2]} / {mision1.maximoObjetos} \n";
            mision1.reward = "Has completado el tutorial del juego, presiona el boton para gritar";
        }
        
        quests.Add(mision1);
    }

    public void updateQuest() {
        string variable = "";
        bool hayAlgo = false;
        variable = $"Encontrar objetos que permitan ver en la noche, se debe encontrar al menos {quests[0].maximoObjetos} de los siguientes objetos: \n";
        for (int i = 0; i < quests.Count; i++) {
            switch (quests[i].nombreQuest) {
                case "Mision 1":
                    foreach (var item in Character.nombreItem) {
                        hayAlgo = true;
                        variable = $"Encontrar objetos que permitan ver en la noche, se debe encontrar al menos {quests[0].maximoObjetos} de los siguientes objetos: \n";
                        if (Questo.ObjetosQuest.Rama.ToString() == item) {
                            quests[i].cantidadObjtenida[0] = Character.cantidadItem[Character.getcantidadItem(item)];
                            variable += $"{Questo.ObjetosQuest.Rama} : {quests[i].cantidadObjtenida[0]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Hoja} : {quests[i].cantidadObjtenida[1]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Cuerda} : {quests[i].cantidadObjtenida[2]} / {quests[i].maximoObjetos} , \n";
                        }
                        if (Questo.ObjetosQuest.Hoja.ToString() == item) {
                            quests[i].cantidadObjtenida[1] = Character.cantidadItem[Character.getcantidadItem(item)];
                            variable += $"{Questo.ObjetosQuest.Rama} : {quests[i].cantidadObjtenida[0]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Hoja} : {quests[i].cantidadObjtenida[1]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Cuerda} : {quests[i].cantidadObjtenida[2]} / {quests[i].maximoObjetos} , \n";
                        }
                        if (Questo.ObjetosQuest.Cuerda.ToString() == item) {
                            quests[i].cantidadObjtenida[2] = Character.cantidadItem[Character.getcantidadItem(item)];
                            variable += $"{Questo.ObjetosQuest.Rama} : {quests[i].cantidadObjtenida[0]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Hoja} : {quests[i].cantidadObjtenida[1]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Cuerda} : {quests[i].cantidadObjtenida[2]} / {quests[i].maximoObjetos} , \n";
                        }
                    }
                    if (hayAlgo == false) {
                        variable += $"{Questo.ObjetosQuest.Rama} : {quests[i].cantidadObjtenida[0]} / {quests[i].maximoObjetos} , \n" +
                                    $"{Questo.ObjetosQuest.Cuerda} : {quests[i].cantidadObjtenida[1]} / {quests[i].maximoObjetos} , \n" +
                                    $"{Questo.ObjetosQuest.Hoja} : {quests[i].cantidadObjtenida[2]} / {quests[i].maximoObjetos} \n";
                    }
                    break;
                case "Mision 2":
                    Debug.Log("Mision 2");
                    foreach (var item in Character.nombreItem) {
                        Debug.Log("Aumentamos el contador de quest por objeto");
                        hayAlgo = true;
                        variable = $"Encontrar objetos que permitan ver en la noche, se debe encontrar al menos {quests[0].maximoObjetos} de los siguientes objetos: \n";
                        if (Questo.ObjetosQuest.Rama.ToString() == item) {
                            quests[i].cantidadObjtenida[0] = Character.cantidadItem[Character.getcantidadItem(item)];
                            variable += $"{Questo.ObjetosQuest.Rama} : {quests[i].cantidadObjtenida[0]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Hoja} : {quests[i].cantidadObjtenida[1]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Roca} : {quests[i].cantidadObjtenida[3]} / {quests[i].maximoObjetos} , \n";
                        }
                        if (Questo.ObjetosQuest.Hoja.ToString() == item) {
                            quests[i].cantidadObjtenida[1] = Character.cantidadItem[Character.getcantidadItem(item)];
                            variable += $"{Questo.ObjetosQuest.Rama} : {quests[i].cantidadObjtenida[0]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Hoja} : {quests[i].cantidadObjtenida[1]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Roca} : {quests[i].cantidadObjtenida[3]} / {quests[i].maximoObjetos} , \n";
                        }
                        Debug.Log(item);
                        if (Questo.ObjetosQuest.Roca.ToString() == item) {
                            Debug.Log("actualizamos la roca");
                            quests[i].cantidadObjtenida[3] = Character.cantidadItem[Character.getcantidadItem(item)];
                            variable += $"{Questo.ObjetosQuest.Rama} : {quests[i].cantidadObjtenida[0]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Hoja} : {quests[i].cantidadObjtenida[1]} / {quests[i].maximoObjetos} , \n";
                            variable += $"{Questo.ObjetosQuest.Roca} : {quests[i].cantidadObjtenida[3]} / {quests[i].maximoObjetos} , \n";
                        }
                        
                    }
                    if (hayAlgo == false) {
                        variable += $"{Questo.ObjetosQuest.Rama} : {quests[i].cantidadObjtenida[0]} / {quests[i].maximoObjetos} , \n" +
                                    $"{Questo.ObjetosQuest.Roca} : {quests[i].cantidadObjtenida[1]} / {quests[i].maximoObjetos} , \n" +
                                    $"{Questo.ObjetosQuest.Hoja} : {quests[i].cantidadObjtenida[3]} / {quests[i].maximoObjetos} \n";
                    }
                    break;
            }
        }
        objetivoQuest.text = variable;
    }

    public void completeQuest() {
        int sumaItem = 0;
        int cantidadRama = 0;
        int cantidadHoja = 0;
        int cantidadRoca = 0;
        int cantidadcuerda = 0;
        foreach (var item in quests) {
            Debug.Log(quests.Count);
            if (item.cantidadObjtenida[0] >= item.maximoObjetos) {
                Debug.Log($"en la posicion {0} hay {item.cantidadObjtenida[0]} rama");
                cantidadRama = 1;
            }
            if (item.cantidadObjtenida[1] >= item.maximoObjetos) {
                Debug.Log($"en la posicion {1} hay {item.cantidadObjtenida[1]} hoja");
                cantidadHoja = 1;
            }
            if (item.cantidadObjtenida[2] >= item.maximoObjetos) {
                Debug.Log($"en la posicion {2} hay {item.cantidadObjtenida[2]} cuerda");
                cantidadcuerda = 1;
            }

            if (item.cantidadObjtenida[3] >= item.maximoObjetos) {
                Debug.Log($"en la posicion {3} hay {item.cantidadObjtenida[3]} roca");
                cantidadRoca = 1;
            }
            if (item.nombreQuest == "Mision 1") {
                sumaItem = cantidadcuerda + cantidadHoja + cantidadRama ;
                Debug.Log(sumaItem);
                if (sumaItem == 3) {
                    Debug.Log($"completamos la mision 1");
                    gameObject.transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(true);
                }
            }
            if (item.nombreQuest == "Mision 2") {
                sumaItem =  cantidadHoja + cantidadRama + cantidadRoca;
                Debug.Log("La suma de los objetos completados"+sumaItem);
                if (sumaItem == 3) {
                    Debug.Log($"completamos la mision 2");
                    gameObject.transform.GetChild(0).transform.GetChild(4).gameObject.SetActive(true);
                }
            }
        }
        
        
    }

}
