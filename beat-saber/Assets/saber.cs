﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saber : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 previousPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("holaaa!!!");
        RaycastHit hit;
        if ( Physics.Raycast( transform.position,transform.forward,out hit,1,layer ) )
        {
            if( Vector3.Angle(transform.position-previousPos,hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
                print("Coliciono!!!");
            }
        }
        previousPos = transform.position;
    }
}