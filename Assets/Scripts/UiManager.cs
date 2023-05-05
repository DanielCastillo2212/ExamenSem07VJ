using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text PuntajeText;
    public Text VidaText;
    public Text ZombieText;
    public Text LlaveText;

    public void PrintPuntaje(int puntos) {
        PuntajeText.text = "Balas: " + puntos;
    }

    public void PrintVida(int vida) {
        VidaText.text = "Vidas: " + vida;
    }

    public void PrintZombie(int zombie) {
        ZombieText.text = "Puntos: " + zombie;
    }

     public void PrintLlave(int llave) {
        LlaveText.text = "Llave: " + llave;
    }
}
