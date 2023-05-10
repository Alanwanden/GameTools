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
        rb.velocity = moveVector*moveSpeed*Time.fixedDeltaTime;
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
    }
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector3.zero;
    }
}
