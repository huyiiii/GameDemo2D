using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MainMonobahvour
{
    public MonsterMovement monsterMovement;
    public CharacterController characterController;
    public Animator animator;
    public Transform model;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMonsterMovement();
    }

    protected virtual void LoadMonsterMovement()
    {
        if(monsterMovement != null) return;
        this.model = transform.Find("Model");
        this.characterController = GetComponent<CharacterController>();               
        this.animator = this.model.GetComponentInChildren<Animator>();
        this.monsterMovement = transform.Find("MonsterMovement").GetComponent<MonsterMovement>();
    }
    protected virtual bool IsGroundede()
    {
        return PlayerController.instance.characterController.isGrounded;
    }   
}
