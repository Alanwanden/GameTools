using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Projectile : MonoBehaviour
{
    [HideInInspector]public Rigidbody _rigidbody;
    public float damageRadius = 1;
    // Start is called before the first frame update
    void Reset()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    
    

}
