using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform start ;
    public Transform end ;
    public float speed = 1;
    public float lenght = 1;
    float begin;
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        float covered = Mathf.PingPong(Time.time - begin, lenght / speed);
        transform.position = Vector3.Lerp(start.position, end.position, covered / lenght);
    }
}
