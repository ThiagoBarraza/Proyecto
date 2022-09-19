using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Vector3 worldPosition;
    [SerializeField] private float planeY = 10.3f;
    [SerializeField] private Camera Camara;
    Plane plane;
    [SerializeField] private GameObject debugObject;
    
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
            if (debugObject)
            {
                debugObject.transform.position = worldPosition;
            }
        }

        /*if(debugObject.transform.position.x < -10 && debugObject.transform.position.x > 10 && debugObject.transform.position.z < -10 && debugObject.transform.position.z > 10)
        {
        Camera will follow debug object, ony if its on the -10/10 x/y area, it should make a smooth translate with a kinda slow speed, because if not the camera could move to fast and be awful, need to think how to make the camera go back after that
         }*/
    }
}
