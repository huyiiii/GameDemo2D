using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Combat
{

    public PlayerController playerController;
    protected override void Update()
    {
        this.AttackUpdate();
        
    }   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStrikePoint();
        this.LoadPlayerController();
    }
    protected virtual void LoadPlayerController()
    {
        if(this.playerController != null)    return;
        this.playerController = transform.parent.GetComponent<PlayerController>();
  
    }
    protected override void LoadStrikePoint()
    {
        this.fxPointRight = PlayerController.instance.PointRight;
    }
    protected override void SpawnSkill()
    {
        if(this.skillReleased)  return;

        this.skillReleased = true;

        Transform fx = SkillManager.instance.Spawn("FireBall");
        fx.position = fxPointRight.position;
        fireBall = fx.GetComponent<FireBallMovement>();
        fireBall.Turnning(PlayerController.instance.playerMovement.isTurningRight);
        fx.gameObject.SetActive(true);
    }
    protected override void Attacking()
    {
        this.Animator().SetBool("Attacking",this.IsAttacking());
       if(this.IsAttacking() && !this.attackLaunched)  
       {
        this.attackLaunched = true;
        Invoke("SpawnSkill",this.spawnSkillDelay);
       
       Invoke("AttackFinish",this.aniAttackTime);
       }
       
    }
    protected override Animator Animator()
    {
        return this.playerController.animator;
    }
}
        