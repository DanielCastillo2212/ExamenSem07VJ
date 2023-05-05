using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public FloorController floorController;
    public LateralController lateralesController;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float jumpForce = 200f;
    private bool canJump=false;
    private bool jumpEnemy=false;
    private int currentAnimation = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame


    public void Salto(){
         currentAnimation = 1;
        
        bool goJump = (floorController.canJump && !lateralesController.nextJump()) || (floorController.canJump && lateralesController.nextJump()) || (!floorController.canJump && lateralesController.nextJump());

        if(goJump){
            currentAnimation = 3;
            //rb.velocity = new Vector2(5, velocityY);
            //rb.AddForce(new Vector2(0, jumpForce));
           this.impulseAdd(this.jumpForce);
            
        }
        
    }

    private void impulseAdd(float jumpForce){
        rb.AddForce(new Vector2(0, jumpForce));
        floorController.canJump = false;
        lateralesController.validationJump();
    }

}
