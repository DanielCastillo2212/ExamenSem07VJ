using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Puntaje = 1000;
    private int Vidas = 2;
    private int Zombies = 0;
    private int VidaZombie = 2;
    private int RespawnVida =2;
    private int VidaGanada = 0;
    private int llave = 0;

    //
    private int contador = 0;
    // Start is called before the first frame update
    
    public void GanarPuntos() {
        Puntaje +=5;
    }
    public void PerderPuntos() {
        Puntaje -=1;
        //
        contador++;
    }

    public void CogerPotion() {
        llave +=1;
    }

    public void MatarZombie() {
        Zombies +=1;
    }

    public void PerderVidas() {
        if(Vidas > 0)
            Vidas -= 1;
    }

    public void PerderVidasZombie() {
        if(VidaZombie > 0)
            VidaZombie -= 1;
    }

    public void GanarVidasZombie() {
        if(VidaZombie == 0)
            VidaZombie+=2;
    }

    public int GetPuntaje() {
        return Puntaje;
    }

    public int GetVidas() {
        return Vidas;
    }
    public int GetVidaZombie() {
        return VidaZombie;
    }

    public int GetVidaZombieGanada() {
        return VidaZombie;
    }

    public int GetZombies() {
        return Zombies;
    }

    public int GetRespawn() {
        return RespawnVida;
    }

    public int GetContador() {
        return contador;
    }

    public int GetPotion() {
        return llave;
    }
}
