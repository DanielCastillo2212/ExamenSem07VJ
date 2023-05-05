using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float velocityX = 0.1f;
    public float velocityY = 0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, velocityY);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colision de bala");
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    
}
