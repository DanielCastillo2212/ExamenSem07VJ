using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    public const int MAX_JUMPS = 1;
    public bool onGround = false;
    public int currentJumps = 0;

    public bool CanJump() {
        return onGround || (!onGround && currentJumps < MAX_JUMPS);
    }

    public void Jump() {
        currentJumps++;
        onGround = true;
            
    }
    

    void OnCollisionEnter2D(Collision2D other) {
        
        Debug.Log("Entrando piso");
        onGround = true;
        currentJumps = 0;
    }
}
