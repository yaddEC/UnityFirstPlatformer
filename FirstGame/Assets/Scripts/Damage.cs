using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    Bumper bounceDamage;
    // Start is called before the first frame update
    void Start()
    {
        bounceDamage = new Bumper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("damaged");
        other.gameObject.GetComponent<PlayerLife>().Hit();
        bounceDamage.Bouncing(other.gameObject, 1);
         }

    }
}
