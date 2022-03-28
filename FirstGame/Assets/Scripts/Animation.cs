using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public Movement Player;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Input.GetAxis("Horizontal"));
       

        if (Player.isGrounded)
            animator.SetBool("Grounded", true);
        else
            animator.SetBool("Grounded", false);


    }
}
