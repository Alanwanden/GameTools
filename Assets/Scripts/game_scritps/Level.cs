using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int exprience;
    
    

    public int CurrentLevel {
        get{ return exprience / 500; }
    }

}