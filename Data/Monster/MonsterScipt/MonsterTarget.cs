using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MonsterTarget : MainMonobahvour
{
    [Header("Monster")]
    [SerializeField] protected Transform target;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.TargetFind();
    }

    protected virtual void TargetFind()
    {
        if(isTargetAvail()) return;
        this.target = PlayerController.instance.playerModel.transform;
        Debug.Log("TargetFind");
    }
    protected virtual bool isTargetAvail()
    {
        if(this.target == null) return false;
        if(!this.target.gameObject.activeSelf)  return false;
        return true;
    }

}
