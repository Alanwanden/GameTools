using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputsActions input = null;
    private Vector3 moveVector = Vector3.zero;
    private Vector3 moveConvert;
    private Rigidbody rb;
    public float moveSpeed = 2f;
    private void Awake()
    {
        input = new InputsActions();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCanceled;
        

    }

    private void FixedUpdate()
    {
        rb.velocity = moveConvert*moveSpeed*Time.fixedDeltaTime;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCanceled;


    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector3>();
        moveConvert = new Vector3(moveVector.x, 0.0f, moveVector.z);
    }
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector3.zero;
    }
}
