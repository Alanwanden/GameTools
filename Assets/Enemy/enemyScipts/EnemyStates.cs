using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates 
{
   public enum STATES
    {
        IDLE,WALK
    }
    public enum EVENT
    {
        ENTER,UPDATE,EXIT
    }
    public STATES name;
    protected EVENT stage;
    protected EnemyStates nextState;

    public EnemyStates()
    {
        stage=EVENT.ENTER;
    }
    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }
    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public EnemyStates Procces()
    {
        if (stage == EVENT.ENTER) { Enter(); }
        if (stage == EVENT.UPDATE) { Update(); }
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        else { return this; }
    }
}
