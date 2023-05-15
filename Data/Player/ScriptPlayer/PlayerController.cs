using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MainMonobahvour
{   

    public static PlayerController instance;
    public Transform playerModel;
    public Transform PointRight;
    public CharacterController characterController;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    public Animator animator;

    protected override void Awake()
    {
        base.Awake();
        if(PlayerController.instance != null)   Debug.LogError("Only 1 PlayerController allow");
        PlayerController.instance = this;
    }


    protected override void LoadComponents()
    {
        this.LoadChar();
    }

    protected virtual void LoadChar()
    {
        if(this.playerModel != null) return;
        this.playerModel = transform.Find("Model");
        this.animator = this.playerModel.GetComponent<Animator>();
        this.playerMovement = transform.Find("PlayerMovement").GetComponent<PlayerMovement>();
        this.PointRight = this.playerModel.Find("RightPoint");
        this.characterController = this.playerModel.GetComponent<CharacterController>();
        Debug.Log(transform.name + ": LoadChar",gameObject);        
        this.playerCombat = transform.Find("PlayerCombat").GetComponent<PlayerCombat>();
    }
}
