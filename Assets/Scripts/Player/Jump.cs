using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour

{
    private InputsActions Input = null;
    public float jumpSpeed;
    private Rigidbody rb;
    private void Awake()
    {
        Input = new InputsActions();
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        Input.Enable();
        Input.Player.Jump.performed += OnJump;


    }
    private void OnDisable()
    {
        Input.Disable();
        Input.Player.Jump.performed -= OnJump;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnJump(InputAction.CallbackContext context)
    {
        Jumping();
    }
    void Jumping()
    {

        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }
}
