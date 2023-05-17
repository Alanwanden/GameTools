using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Louncher : MonoBehaviour
{
    public Rigidbody projectile;
   
    
    public Vector3 offset = Vector3.forward;
    [Range(0, 100)] public float velocity = 10f;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public void Fire()
    {
       
            var bullet = Instantiate(projectile, transform.TransformPoint(offset), transform.rotation);
            bullet.velocity = Vector3.forward * velocity;
        
     
    }
   
}
