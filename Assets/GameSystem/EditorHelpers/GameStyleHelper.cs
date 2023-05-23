using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStyleHelper : MonoBehaviour
{
    public Camera mainCamera;
    
    public Vector3 sideViewTransform=new Vector3(2f,0f,-10f);
    public Vector3 sideViewRot=new Vector3(0, 0f,0f);
    public Vector3 forwarViewTransform=new Vector3(0,3f,-10f);
    public Vector3 forwarViewRot=new Vector3(0,0f,0f);
    public Vector3 topDownViewTransform = new Vector3(0, 10f, 3f);
    public Vector3 topDownViewRot = new Vector3(90f, 0, 0);

    
    public void OnEnable()
    {
        
        mainCamera = Camera.main;
        
    }
    public void TwoD()
    {

    }
    public void SideWiew()
    {
        
        SetCamera(sideViewTransform,sideViewRot,true);

    }
    public void Forward()
    {
        SetCamera(forwarViewTransform,forwarViewRot,false);


    }
    public void TopDownView()     
    {
        SetCamera(topDownViewTransform, topDownViewRot, true);
    }
    public void RunnerGame()
    {
        Debug.Log("Camera is Static");
    }

    public string cameraTarget = "";
    public void PlatformGame()
    {
        
        if (this.gameObject.GetComponent<CameraController>()==null)
        {
            this.gameObject.AddComponent<CameraController>();
        }
        
        GetComponent<CameraController>().target = GameObject.FindGameObjectWithTag(cameraTarget);
    }


    private void SetCamera(Vector3 pos, Vector3 rot,bool projector)
    {
        mainCamera.orthographic = projector;
      
        mainCamera.transform.position=pos;
        mainCamera.transform.eulerAngles = rot;
    }
    
}
