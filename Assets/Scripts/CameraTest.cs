using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Vector3 worldPosition;
    [SerializeField] private float planeY = 10.3f;
    [SerializeField] private Camera Camara;
    Plane plane;
    [SerializeField] private Transform debugObject;
    
    void Start()
    {
       plane = new Plane(Vector3.up, planeY);
    }

    void Update()
    {
        float distance;
        Vector3 forward = Camara.transform.TransformDirection(Vector3.forward) * 50;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(rayo, out distance))
        {
            worldPosition = rayo.GetPoint(distance);
            Debug.DrawRay(Camara.transform.position, forward , Color.red);
            debugObject.position = worldPosition;
        }
    }
}
