using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSight : MonoBehaviour
{
    //public GameObject Debug;
    public Vector3 Location;
    [SerializeField] GameObject DebugObj2;
    [SerializeField] Transform DebugObj;
    [SerializeField] Pause PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = FindObjectOfType<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        var collider = GetComponent<SphereCollider>();

        Vector3 closestPoint = collider.ClosestPoint(DebugObj.position);
        if (DebugObj2)
        {
                DebugObj2.transform.position = closestPoint;
        }
        
    }

}
