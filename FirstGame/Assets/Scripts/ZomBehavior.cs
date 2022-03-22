using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private CapsuleCollider CapsuleCollider;
    public LayerMask groundLayer;
    float horizontal = 7f;
    public bool EdgeOrWall = false;
    public bool isEnemy = false;
    Vector3 pos;
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
        pos = transform.position +dir * CapsuleCollider.radius /*+ Vector3.back * CapsuleCollider.radius*/;
        EdgeOrWall = (Physics.CheckSphere(pos, CapsuleCollider.radius, groundLayer));

        if (EdgeOrWall && isEnemy)
        {
            horizontal *=-1;
            dir*=-1;
            transform.Rotate(rotation);
        }
     
        

    }


    void FixedUpdate()
    {
        float moveFactor = horizontal * Time.fixedDeltaTime;


        rb.velocity = new Vector3(0, 0, moveFactor * 10f);

    }
}
