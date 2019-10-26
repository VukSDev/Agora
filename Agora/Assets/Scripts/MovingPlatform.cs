using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public GameObject platform;

    public float speed;

    bool forward;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float step = speed * Time.deltaTime;
        if(platform.transform.position == posA.position)
        {
            forward = true;
        }

        if(platform.transform.position == posB.position)
        {
            forward = false;
        }        

        if(forward)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, posB.position, speed * Time.deltaTime);
        }

        if(!forward)
        {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, posA.position, step);
        }
    }
}
