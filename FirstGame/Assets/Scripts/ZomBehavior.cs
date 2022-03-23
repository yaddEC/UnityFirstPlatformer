using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private CapsuleCollider CapsuleCollider;
    public LayerMask edgeLayer;
    float horizontal = 7f;
    public bool EdgeOrWall = false;
    Vector3 pos;
    Ray ray;
    Vector3 dir= Vector3.forward;
    Vector3 rotation = new Vector3(0, 180, 0);
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
       
        EdgeOrWall = Physics.Raycast(transform.position + dir * 0.8f, dir,0.2f, edgeLayer);

        if (EdgeOrWall)
        {
            horizontal *=-1;
            dir*=-1;
            transform.Rotate(rotation);
        }
     
        

    }


    void FixedUpdate()
    {
        float moveFactor = horizontal * Time.fixedDeltaTime;
        Debug.DrawRay(ray.origin, ray.direction * 10);

        rb.velocity = new Vector3(0, 0, moveFactor * 10f);

    }
}
