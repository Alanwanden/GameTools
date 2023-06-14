using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    EnemyStates currentState;  

    public Animator armR,armL,legR,legL;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = new Enemy_Idle();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Procces();
    }
}
