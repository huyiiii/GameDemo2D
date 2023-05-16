using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MainMonobahvour
{
    [SerializeField]  protected List<Transform> fxs = new List<Transform>();
    public static   SkillManager instance;

    protected override void Awake()
    {
        base.Awake();
        if(SkillManager.instance != null)   Debug.LogError("Only 1 SkillManager allow");
        SkillManager.instance = this;
        this.HideAll();
    }

    protected override void LoadComponents()
    {
            this.LoadFXS();
    }

    protected virtual void LoadFXS()
    {
        if(this.fxs.Count > 0) return;
        foreach(Transform chill in transform)
        {
            this.fxs.Add(chill);
        }
        Debug.Log(transform.name +  ":LoadFXS ",gameObject);
    }
    protected virtual void HideAll()
    {
        foreach(Transform fx in this.fxs)
        {
            fx.gameObject.SetActive(false);
        }
    }
    public virtual Transform Spawn(string fxName)
    {
        Transform fx = Instantiate(this.fxs[0]);
        return fx;
    }
}
