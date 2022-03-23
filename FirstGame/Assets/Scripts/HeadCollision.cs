using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{
    public LayerMask edgeLayer;
    public GameObject Enemy;
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
            if (Physics.Raycast(other.transform.position, Vector3.down, 0.2f, edgeLayer));
            {
                Debug.Log("ded");
                bounceHead.Bouncing(other.gameObject, 2);
                Destroy(Enemy);

            }
        }

    }
}
