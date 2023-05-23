using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    public GameObject target=null;
    // Start is called before the first frame update
    private void Awake()
    {
        _camera = GetComponent<GameStyleHelper>().mainCamera;
    }
    void Start()
    {
        
    }
    private void LateUpdate()
    { if(target != null)
        {
            Follow(target);
        }
        
    }
    void Follow(GameObject target)  {
        _camera.transform.position=new Vector3(target.transform.position.x,transform.position.y,transform.position.z);
    }

}
