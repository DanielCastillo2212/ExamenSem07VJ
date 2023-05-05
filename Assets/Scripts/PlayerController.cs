using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioClip[] audios;
    public GameObject gameManager;
    public GameObject bala;
    public FootController footController;
    public GameObject ButtonEntrar;

    private Animator animator;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Transform balaTransform;
    
    private int currentAnimation = 1;
    public float jumpForce = 1000f;
    public float tiempoDeRetraso = 2.0f;
    public int vida = 3;
    public bool Muerte = false;
    private bool balaExiste = false;

    public bool entroPuerta = false;
    public bool puedeDisparar = false;
    public bool encimaBoton = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Saltar();
        //Disparar();
        //CambioEscena();
        /*
        GameObject[] objetosConNuevoTag1 = GameObject.FindGameObjectsWithTag("Boton");
                foreach (GameObject objeto in objetosConNuevoTag1) {
                objeto.SetActive(false);
                }
        */
        DetectarBotonOff();
        Debug.Log("Primera bandera detectada " + encimaBoton);
        if(encimaBoton == true){
          //DetectarBotonOn();
          ButtonEntrar.SetActive(true);

        }
        DividirDisparo();
        animator.SetInteger("Estado", currentAnimation);
    }

    //Movimiento con botones

    public void MoverIzquierda(){
      rb.velocity = new Vector2(-10, rb.velocity.y);
    }

    public void MoverDerecha(){
      rb.velocity = new Vector2(10, rb.velocity.y);
    }

    public void Detener(){
      rb.velocity = new Vector2(0, rb.velocity.y);
    }

    
    public void Saltar() {
      if(footController.CanJump()) {
            rb.AddForce(new Vector2(0, jumpForce));
            footController.Jump();
            MusicaSaltar();
        }
    }
    
    //Metodos de sonidos 
    public void MusicaSaltar(){
      audioSource.PlayOneShot(audios[0], 0.2f);
    }

    public void MusicaDisparo(){
      audioSource.PlayOneShot(audios[1]);
    }

    private void Disparar() {

      var gm = gameManager.GetComponent<GameManager>();
      var uim = gameManager.GetComponent<UiManager>();
      int BalaMoneda = gm.GetPuntaje();


      /*
      if(BalaMoneda > 0 && Input.GetKeyUp(KeyCode.U)) {
        audioSource.PlayOneShot(audios[1]);
        balaExiste = true;
        var position = transform.position;
        var x = position.x + 1;
        var newPosition = new Vector3(x, position.y, position.z);
        
        GameObject balaGenerada = Instantiate(bala, newPosition, Quaternion.identity);
        balaTransform = balaGenerada.transform;
        
        gm.PerderPuntos();
        uim.PrintPuntaje(gm.GetPuntaje());
        //GanarPuntos();
      }
      */

       if(BalaMoneda > 0) {
        MusicaDisparo();
        balaExiste = true;
        var position = transform.position;
        var x = position.x + 1;
        var newPosition = new Vector3(x, position.y, position.z);
        
        GameObject balaGenerada = Instantiate(bala, newPosition, Quaternion.identity);
        balaTransform = balaGenerada.transform;
        
        gm.PerderPuntos();
        uim.PrintPuntaje(gm.GetPuntaje());
        //GanarPuntos();
      }
    }

    public void EmpezarDisparo(){
        Disparar();
    }

    /*
    //Cambio de escena al matar 5 zombies
    private void CambioEscena(){

      var gm = gameManager.GetComponent<GameManager>();
      var uim = gameManager.GetComponent<UiManager>();
      int countZombies = gm.GetZombies();
      int countLlave = gm.GetPotion();
      //int countMetod = gm.GetContador();

      if(countZombies == 5 && dentroPuerta && countLlave == 1 ){
        SceneManager.LoadScene("Scena3");
      }
      /*
      if(countMetod >= 3){
        SceneManager.LoadScene("Scena3");
        countMetod = 0;
      }
      
    }
    */
    private void DividirDisparo() {
      // solo se divide si la bala existe y presiono O
      //transform.position
      if(balaExiste && Input.GetKeyUp(KeyCode.O)) {

        var position = balaTransform.position;
        var positionBala2 = new Vector3(position.x + 1, position.y + 1, position.z); 
        var positionBala3 = new Vector3(position.x + 1, position.y - 1, position.z); 

        GameObject balaGenerada2 = Instantiate(bala, positionBala2, Quaternion.identity);

        (balaGenerada2.GetComponent<BalaController>()).velocityY = 1;

        GameObject balaGenerada3 = Instantiate(bala, positionBala3, Quaternion.identity);

        (balaGenerada3.GetComponent<BalaController>()).velocityY = -1;
      }
    }

    private void GanarPuntos() {
      var gm = gameManager.GetComponent<GameManager>();
      var uim = gameManager.GetComponent<UiManager>();

      gm.GanarPuntos();
      uim.PrintPuntaje(gm.GetPuntaje());
    }

    private void contadorPotion() {
      var gm = gameManager.GetComponent<GameManager>();
      var uim = gameManager.GetComponent<UiManager>();

      gm.CogerPotion();
      uim.PrintLlave(gm.GetPotion());
    }

    //Colisión para morir
    private void OnCollisionEnter2D(Collision2D other){
        Muerte = false;
        currentAnimation = 1;
      if (other.gameObject.CompareTag("Enemy")){

          audioSource.PlayOneShot(audios[3], 0.5f);
          gameManager = GameObject.Find("GameManager");
          var gm = gameManager.GetComponent<GameManager>();
          var uim = gameManager.GetComponent<UiManager>();

          gm.PerderVidas();
          uim.PrintVida(gm.GetVidas());

          int morir = gm.GetVidas();

          if(morir == 0){
            audioSource.PlayOneShot(audios[4]);
            Muerte = true;
            Debug.Log("Muerte");
            currentAnimation = 2;
            Invoke("DetenerTiempo", tiempoDeRetraso);
          } 

          
          //Destroy(this.gameObject);
          //currentAnimation = 5;

      }
    }

    public void OnTriggerEnter2D(Collider2D other)
    { 
        /*
        // Si el objeto que ha entrado en el trigger tiene la etiqueta "Coin", entonces lo hacemos desaparecer
        if (other.gameObject.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(audios[2]);
            //Debug.Log("OnTrigger");
            other.gameObject.SetActive(false);
            GanarPuntos();
            //jumpEnemy = true;
        }
        */

        
        if (other.gameObject.CompareTag("Puerta"))
        {
            //audioSource.PlayOneShot(audios[2]);
            //Debug.Log("OnTrigger");
            //other.gameObject.SetActive(false);
            //contadorPotion();
            //jumpEnemy = true;

            
            var gm = gameManager.GetComponent<GameManager>();
            var uim = gameManager.GetComponent<UiManager>();
            int countZombies = gm.GetZombies();
            int countLlave = gm.GetPotion();
            //int countMetod = gm.GetContador();

            Debug.Log("Estoy en la puerta");
            bool goNextScene = ((countZombies >= 5 && countLlave == 1));
            if(goNextScene){

                encimaBoton = true;
                Debug.Log(encimaBoton);
                //SceneManager.LoadScene("Scena3");
                //BotonEntrar();
                //Funcion para activar boton
            }
        }

        if (other.gameObject.CompareTag("Potion"))
        {
            //audioSource.PlayOneShot(audios[2]);
            //Debug.Log("OnTrigger");
            other.gameObject.SetActive(false);
            contadorPotion();
            //jumpEnemy = true;
        }
    }

    public void DetectarBotonOff(){
      //Debug.Log("Esta buscando otro tag");
      GameObject[] objetosConNuevoTag1 = GameObject.FindGameObjectsWithTag("Boton");
      foreach (GameObject objeto in objetosConNuevoTag1) {
                objeto.SetActive(false);
                }
    }
    /*
    public void DetectarBotonOn(){
      //Debug.Log("Esta buscando otro tag");
      GameObject[] objetosConNuevoTag1 = GameObject.FindGameObjectsWithTag("Boton");
      foreach (GameObject objeto in objetosConNuevoTag1) {
                objeto.SetActive(true);
                }
    }
    */
    public void BotonEntrar()
    {
        entroPuerta = true;
        Debug.Log("Se presionó el boton");
        SceneManager.LoadScene("Scena3");
    }


    public void DetenerTiempo()
    {
        Time.timeScale = 0;
    }

    public void ReanudarTiempo()
    {
        Time.timeScale = 1;
    }

    public void EscenaPrincipal()
    {
        SceneManager.LoadScene("Scene1");
    }

}
