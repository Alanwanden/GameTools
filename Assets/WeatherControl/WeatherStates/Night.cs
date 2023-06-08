using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Night : States
{
    public Night() : base()
    {
        name = WEATHERTYPES.NIGTH;

    }
    public override void Enter()
    {
        Debug.Log(name);
        base.Enter();
    }
    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            nextState = new Rainy();
            stage = EVENT.EXIT;

        }

    }
    public override void Exit()
    {
        base.Exit();
    }
}
