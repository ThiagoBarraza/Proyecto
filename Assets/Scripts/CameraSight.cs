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
        if (!PS.gameIsPaused)
        {
            var collider = GetComponent<SphereCollider>();

            Vector3 closestPoint = collider.ClosestPoint(DebugObj.position);
            if (DebugObj2)
            {
                DebugObj2.transform.position = closestPoint;
            }
        }
    }

    public void OnDrawGizmos()
    {
        //var collider = GetComponent<SphereCollider>();

        //Vector3 closestPoint = collider.ClosestPoint(DebugObj.position);
        //DebugObj2.transform.position = closestPoint;
        //Gizmos.DrawSphere(Location, 0.1f);
        //Gizmos.DrawWireSphere(closestPoint, 0.1f);
    }
}
