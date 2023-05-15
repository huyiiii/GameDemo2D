using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MainMonobahvour
{
    public bool isTurnRight = true;
    [SerializeField] public float speed = 9f;
    [SerializeField] protected Transform model;
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected virtual void Update()
    {
        Vector3 dir = transform.right;
        if(!this.isTurnRight) dir *= -1;
        transform.position +=  dir*this.speed*Time.deltaTime;
    }

    protected virtual void LoadModel()
    {
        if(this.model != null)  return;

        this.model = transform.Find("Model");
        Debug.Log(transform.name +": LoadModel "+gameObject); 
    }
    
    public virtual void Turnning(bool _isTurnRight)
    {
        this.isTurnRight = _isTurnRight;
        Vector3 scale = this.model.localScale;
        if(this.isTurnRight) scale.x =1f;
        else scale.x = -1f;
        this.model.localScale = scale;
    }
}
