using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public bool canJump = false;
    public int currentJump = 0;
    // Start is called before the first frame update
    
     void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        canJump=true;
    }
}
