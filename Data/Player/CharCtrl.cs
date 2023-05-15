using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharCtrl : MainMonobahvour
{
    public CharacterController characterController;
    [Header("Moving")]
    public Vector3 moveMent = new Vector3(0,0,0);
    public bool isMoving = false;
    public float speed = 2;
    public bool grounded;

    [Header("Jumping")]
    public bool isJump;
    public float jumpHeight = 9f;
    public float gravityValue = -9.81f;

     protected virtual void Jumping()
    {
        if(!this.grounded)    return;
        if(isJump) this.moveMent.y = this.jumpHeight;
    }

    protected virtual void Falling()
    {
        this.moveMent.y += gravityValue * Time.deltaTime;
       
    }

    protected abstract void Moving();
    protected abstract bool IsGroundede();
   
 
}
