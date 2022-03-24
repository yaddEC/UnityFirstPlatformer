using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private CapsuleCollider CapsuleCollider;
    public LayerMask edgeLayer;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    private bool isNear;
    public float JumpHeight = 5f;
    public float walkingSpeed=10;
    public float followingSpeed = 25;
    public float detectionZone = 6.5f;
    public Transform target;
    float horizontal=1;
    public bool EdgeOrWall = false;
    public bool isGrounded;
    public bool jumped=false;
    public float gravity;
    Vector3 pos;
    Ray ray;
    Vector3 dir = Vector3.forward;
    Vector3 rotation = new Vector3(0, 180, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
    
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position + (Vector3.up * 0.9f) * CapsuleCollider.radius;
        isGrounded = Physics.CheckSphere(pos, CapsuleCollider.radius, groundLayer);
        isNear = Physics.CheckSphere(transform.position, detectionZone, playerLayer);
        EdgeOrWall = Physics.Raycast(transform.position + dir * 0.8f, dir, 0.3f, edgeLayer);
        if (isNear)
        {
            if(transform.position.z>target.position.z+0.5f)
            {
                if (horizontal > 0) ;
                    horizontal = -1;
              
                dir = Vector3.forward* -1;
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if(transform.position.z < target.position.z-0.5f)
            {
                if (horizontal < 0) ;
                    horizontal =1;

                dir = Vector3.forward;
                transform.rotation = new Quaternion(0, 0, 0,0);
            }
            else
            {
                horizontal = 0;
            }
            if (EdgeOrWall && !jumped)
            {
                jumped = true;
                gravity += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);
            }

        }
        else
        {
            if (EdgeOrWall)
            {
                horizontal *= -1;
                dir *= -1;
                transform.Rotate(rotation);
            }
        }
      
        if (isGrounded && gravity < 0)
        {
            gravity = 0f;
            jumped = false;
        }
            

        
        gravity += Physics.gravity.y * Time.deltaTime;
    }


    void FixedUpdate()
    {
        
        Debug.DrawRay(transform.position + dir * 0.8f, dir * 10);
        if (isNear)
        {

            float moveFactor = horizontal*followingSpeed * Time.fixedDeltaTime;
            rb.velocity = new Vector3(0, gravity, moveFactor * 10);
        }
        else
        {
            float moveFactor = horizontal * walkingSpeed * Time.fixedDeltaTime;
            rb.velocity = new Vector3(0, gravity, moveFactor * 10);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color= new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, detectionZone);
    }

}
