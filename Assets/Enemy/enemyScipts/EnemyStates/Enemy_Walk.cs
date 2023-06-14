using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : EnemyStates
{
    public Animator[] allbody;
    public Enemy_Walk() : base() {
        name = STATES.WALK;
    }
    
    public override void Enter()
    {

        base.Enter();
    }
    public override void Update()
    {
        foreach (var animator in allbody) {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            nextState = new Enemy_Idle();
            stage = EVENT.EXIT;

        }
    }
    public override void Exit()
    {
        foreach (var animator in allbody)
        {
            animator.SetBool("isWalking", false);
        }

        base.Exit();
    }
}
