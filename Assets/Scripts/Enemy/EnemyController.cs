using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    /*
    void Update()
    {
        MatarZombie();
    }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colision de bala");
        if (other.gameObject.CompareTag("Bala"))
        {
          gameManager = GameObject.Find("GameManager");
          var gm = gameManager.GetComponent<GameManager>();
          var uim = gameManager.GetComponent<UiManager>();

          gm.PerderVidasZombie();

          int morirZombie = gm.GetVidaZombie();

          if(morirZombie == 0){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            MatarZombie();
            gm.GanarVidasZombie();
           } 

        }
    }

    private void MatarZombie(){

      //(field) GameObject EnemyController.GameManager;
      gameManager = GameObject.Find("GameManager");
      var gm = gameManager.GetComponent<GameManager>();
      var uim = gameManager.GetComponent<UiManager>();

      gm.MatarZombie();
      uim.PrintZombie(gm.GetZombies());
    }
}
