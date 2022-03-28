using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollision : MonoBehaviour
{
    public LayerMask bumperLayer;
    public GameObject Boss;
    Bumper bounceHead;
    // Start is called before the first frame update
    void Start()
    {
        bounceHead = new Bumper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
                      bounceHead.Bouncing(other.gameObject, 6);
                    Boss.gameObject.GetComponent<Boss>().Hit();
        


            
        }

    }
}

