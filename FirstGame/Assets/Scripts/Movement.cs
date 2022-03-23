using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    private Rigidbody rb;
    private CapsuleCollider CapsuleCollider;
    public LayerMask groundLayer;
    public LayerMask bumpLayer;
 
    public float GroundDistance = 5.1f;
    public float JumpHeight = 5f;
    [Range(0, 100f)] [SerializeField] private float speed = 40f;
    Ray ray;
    public float gravity;


    public float horizontal = 0f;
    
    public bool isGrounded ;


    public Vector3 pos;
    public void Bouncing(float height)
    {
        gravity += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CapsuleCollider = GetComponent<CapsuleCollider>();

        
    }


    void Update()
    {

        pos = transform.position + Vector3.up * CapsuleCollider.radius;
        isGrounded = Physics.CheckSphere(pos, CapsuleCollider.radius, groundLayer);
       
       

        horizontal = Input.GetAxisRaw("Horizontal") * speed; 

        if (isGrounded && gravity < 0)
            gravity = 0f;

        if (Input.GetButtonDown("Jump") && isGrounded)
            Bouncing(JumpHeight);
        

        gravity += Physics.gravity.y * Time.deltaTime;
    }

    void FixedUpdate()
    {
        float moveFactor = horizontal * Time.fixedDeltaTime;

        Debug.DrawRay(ray.origin, ray.direction * 10);
        
        rb.velocity = new Vector3(0, gravity, moveFactor * 10f);
        
    }
}