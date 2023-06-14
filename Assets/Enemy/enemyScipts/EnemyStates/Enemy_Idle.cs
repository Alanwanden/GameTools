using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Idle : EnemyStates
{
    public Animator[] allbody;
    public EnemyAI AI;
    public Enemy_Idle() : base() {
        name = STATES.IDLE;

    }

    public override void Enter()
    {
        
        base.Enter();
    }
    public override void Update()
    {
        foreach (var animator in allbody)
        {
            animator.SetBool("isIdle", true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            nextState = new Enemy_Idle();
            stage = EVENT.EXIT;
            
        }
    }
    public override void Exit()
    {
        foreach (var animator in allbody)
        {
            animator.SetBool("isIdle", false);
        }
        base.Exit();
    }



}
