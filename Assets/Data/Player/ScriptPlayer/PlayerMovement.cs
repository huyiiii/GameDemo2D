using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharCtrl
{
    public PlayerController playerController;
    [Header("Walking")]
    public bool isTurningRight = true;
    protected virtual void Update()
    {
        this.grounded = this.IsGroundede();

        this.Jumping();
        this.Falling();
        this.Moving();
        this.Turning();

        this.Animation();
        PlayerController.instance.characterController.Move(this.moveMent * Time.deltaTime);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerMovement();
    }   
    protected virtual void LoadPlayerMovement()
    {
        if(this.characterController != null)    return;
        this.playerController = transform.parent.GetComponent<PlayerController>();
        this.characterController = playerController.characterController;
    }
    protected override void Moving()
    {

        this.moveMent.x = this.moveHorizontal*speed;
    }
    protected virtual void Animation()
    {
        if(this.IsMoving()) this.Animoving();
        else this.AniAdle();
    }

    protected virtual void Animoving()
    {
        PlayerController.instance.animator.SetInteger("Stage",1);

    }
    protected virtual void AniAdle()
    {
        PlayerController.instance.animator.SetInteger("Stage",0);

    }

    protected override bool IsGroundede()
    {
        return PlayerController.instance.characterController.isGrounded;
    }   
    public virtual bool IsMoving()
    {
        this.isMoving = false;
        if(this.isJump) this.isMoving = true;
        if(this.moveHorizontal != 0) this.isMoving =true;
        return this.isMoving;
    }

    protected virtual void Turning()
    {
        this.isTurningRight = true;
        if(this.moveMent.x != 0)   this.lastDirection = this.moveMent.x;
        if(this.lastDirection <0 )    this.isTurningRight = false;
        
        Vector3 scale = PlayerController.instance.playerModel.localScale;
    
        if(this.isTurningRight)    scale.x = 1f;
        else scale.x = -1f;                              
        PlayerController.instance.playerModel.localScale = scale;
        
    }


}

