using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day :States
{ 
    public Day():base() {
        name = WEATHERTYPES.DAY;
    }
    public override void Enter()
    
    {
            Debug.Log(name);
        base.Enter();    

    }
    public override void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)) {
            nextState = new Night();
            stage = EVENT.EXIT;

        }
    }
    public override void Exit() { base.Exit();}
}
