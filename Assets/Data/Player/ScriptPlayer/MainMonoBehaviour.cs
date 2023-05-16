using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMonobahvour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        //For override
    }
    protected virtual void FixedUpdate()
    {
        //for override
    }
}
