using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    private InputsActions input = null;
    public GameObject Projecticlie;
    public Transform pos;

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
        pos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("FireAction")]
    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Firing");
        Instantiate(Projecticlie,pos.position,pos.rotation);
    }
}
