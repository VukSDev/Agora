using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParent : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject == player)
        {
            player.transform.parent = transform;
            print("ouch");
        }
    }
    void OnCollisionExit(Collision col) 
    {
        if(col.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
