﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSight : MonoBehaviour
{
    //public GameObject Debug;
    public Vector3 Location;
    [SerializeField] GameObject DebugObj2;
    [SerializeField] Transform DebugObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrawGizmos()
    {
        var collider = GetComponent<SphereCollider>();

        Vector3 closestPoint = collider.ClosestPoint(DebugObj.position);
        DebugObj2.transform.position = closestPoint;
        Gizmos.DrawSphere(Location, 0.1f);
        Gizmos.DrawWireSphere(closestPoint, 0.1f);
    }
}
