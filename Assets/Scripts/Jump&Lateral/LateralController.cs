using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralController : MonoBehaviour
{
    public bool JumpWall = false;

    public bool nextJump(){
        if(JumpWall){
            return true;
        }
        return false;
    }

    public void validationJump(){
        JumpWall = false;
    }

    public void OnCollisionStay2D(Collision2D other){
        JumpWall = true;
    }
}
