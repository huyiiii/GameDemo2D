using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : CharCtrl
{
    public MonsterController monsterCtrl;
    
    [Header("Moving")]
    Vector3 moveInput;
    public bool isTurningRight = true;

    protected virtual void Update()
    {
        this.Falling();
    
       this.monsterCtrl.characterController.Move(this.moveMent * Time.deltaTime);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMonsterCtrl();
    }

    protected virtual void LoadMonsterCtrl()
    {
        if(this.monsterCtrl != null)    return;
       
        this.monsterCtrl = transform.parent.GetComponent<MonsterController>();
         this.characterController = this.monsterCtrl.characterController;
    }

    protected override void Moving()
    {
        moveInput.x = moveHorizontal;
        characterController.Move(moveInput*Time.deltaTime);
    }
    protected override bool IsGroundede()
    {
        return PlayerController.instance.characterController.isGrounded;
    }   
}
