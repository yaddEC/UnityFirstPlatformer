using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bumper : MonoBehaviour
{
    float _velocity;

    public void Bouncing(GameObject player, float JumpHeight)
    {
         player.GetComponent<Movement>().gravity = Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("bumped");
        Bouncing(other.gameObject, 7);
        }
    }
}
