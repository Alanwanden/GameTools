using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainy : States
{
   public Rainy() : base() {
        name = WEATHERTYPES.RAINY;
    }
    public override void Enter()
    {
        Debug.Log(name);
        base.Enter();
    }
    public override void Update()
    {
     if(Input.GetKeyDown(KeyCode.Space))
        {
            nextState = new Day();
            stage = EVENT.EXIT;

        }
    }
    public override void Exit() { base.Exit();}
}
