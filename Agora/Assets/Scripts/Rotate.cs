using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 90;
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
