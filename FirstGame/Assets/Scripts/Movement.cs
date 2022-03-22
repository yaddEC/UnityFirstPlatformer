using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    private Rigidbody rb;
    private CapsuleCollider CapsuleCollider;
    public LayerMask groundLayer;
 
    public float GroundDistance = 5.1f;
    public float JumpHeight = 5f;
    [Range(0, 100f)] [SerializeField] private float speed = 40f;

    private float gravity;


    public float horizontal = 0f;
    
    public bool isGrounded ;
    

    public Vector3 pos;

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
            gravity += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);

        gravity += Physics.gravity.y * Time.deltaTime;
    }

    void FixedUpdate()
    {
        float moveFactor = horizontal * Time.fixedDeltaTime;


        rb.velocity = new Vector3(0, gravity, moveFactor * 10f);
    }
}