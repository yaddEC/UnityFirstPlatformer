using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCam;
    Vector3 StartCam = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        StartCam = MainCam.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        MainCam.transform.position = new Vector3(MainCam.transform.position.x,  Player.transform.position.y+2.5f, Player.transform.position.z);
    }
}
