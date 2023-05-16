using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat : MainMonobahvour
{
    [Header("Combat")]
    [SerializeField] protected float Attack = 0f;
    protected bool canAttack = false;
    public float AttackSpeed = 2f;
    public float AttackTimer = 0f;
    public bool skillReleased = false;
    public bool attackLaunched = false;
    protected bool strickeRight = true;
    public Transform fxPointRight;
    public float spawnSkillDelay = 0.5f;
    public float aniAttackTime = 0.5f;
    public FireBallMovement fireBall;
    protected abstract  Animator Animator();
    protected abstract void SpawnSkill();
    protected abstract void LoadStrikePoint();
    protected virtual void Update()
    {
        this.AttackUpdate();
        
    }

    protected virtual void AttackUpdate()
    {
        this.AttackDelay();
        this.Attacking();
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStrikePoint();
    }



    public virtual void SetAttacking(float status)
    {
        this.Attack = status;
    }

    protected virtual void AttackDelay()
    {
        this.AttackTimer += Time.deltaTime;
        if(this.AttackTimer < this.AttackSpeed) return;
        this.canAttack = true;    
    }


    protected virtual void Attacking()
    {
        this.Animator().SetBool("Attacking",this.IsAttacking());
       if(this.IsAttacking() && !this.attackLaunched)  
       {
        this.attackLaunched = true;
        Invoke("SpawnSkill",this.spawnSkillDelay);
       
       Invoke("AttackFinish",this.aniAttackTime);
       }
       
    }

    protected virtual void AttackFinish()
    {
        this.canAttack = false;
        this.AttackTimer = 0;
        this.skillReleased = false;
        this.attackLaunched = false;
    }
    protected virtual void Attacked()
    {
        SpawnSkill();
        this.canAttack = false;
        this.AttackTimer = 0;
    }
    public virtual bool IsAttacking()
    {
        return this.Attack != 0 && this.canAttack;
        
    }
   
 
}
