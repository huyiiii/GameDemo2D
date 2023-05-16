using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCombat : Combat
{
    [Header("Monster")]
    public MonsterController monsterController;
    protected override void Update()
    {
        this.AttackUpdate();
        
    }   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStrikePoint();
        this.LoadMonsterController();
    }
    protected virtual void LoadMonsterController()
    {
        if(this.monsterController != null)    return;
        this.monsterController = transform.parent.GetComponent<MonsterController>();
  
    }
    protected override void LoadStrikePoint()
    {
        this.fxPointRight = transform.Find("MonsterRP");
    }
    protected override void SpawnSkill()
    {
        if(this.skillReleased)  return;

        this.skillReleased = true;

        Transform fx = SkillManager.instance.Spawn("FireBall");
        fx.position = fxPointRight.position;
        fireBall = fx.GetComponent<FireBallMovement>();
        fireBall.Turnning(this.monsterController.monsterMovement.isTurningRight);
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
       return this.monsterController.animator;
    }
}
