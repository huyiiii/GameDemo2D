using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MainMonobahvour
{
    protected float moveHorizontal =0; 
    public bool isJump = false;
    public float Attacking = 0;
    // Update is called once per frame
    void Update()
    {
        this.PlayerInput();
    }

    protected virtual void PlayerInput()
    {
        //this jump
        this.isJump = Input.GetButtonDown("Jump")
            || Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.UpArrow);
        PlayerController.instance.playerMovement.isJump = this.isJump;
        //Walking
        this.moveHorizontal = Input.GetAxis("Horizontal");
        PlayerController.instance.playerMovement.moveHorizontal = this.moveHorizontal;

        //Attacking
        this.Attacking = Input.GetAxis("Fire1");
        PlayerController.instance.playerCombat.SetAttacking(this.Attacking);
    }
}