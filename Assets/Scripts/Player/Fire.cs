using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    private InputsActions input = null;
    // Start is called before the first frame update
    private void Awake()
    {
        input = new InputsActions();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Fire.performed += OnFire;
        
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Fire.canceled -= OnFire;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Firing");
    }
}
