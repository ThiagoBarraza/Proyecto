using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Vector3 worldPosition;
    public Transform pointer;
    public float planeY = 10.3f;
    [SerializeField] private Camera camera;
    Plane plane;
    public Transform debugObject;
    // Start is called before the first frame update
    
    void Start()
    {
       plane = new Plane(Vector3.up, planeY);
    }

    // Update is called once per frame
    void Update()
    {
        float distance;
        Vector3 forward = camera.transform.TransformDirection(Vector3.forward) * 50;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(rayo, out distance))
        {
            worldPosition = rayo.GetPoint(distance);
            Debug.DrawRay(camera.transform.position, forward , Color.red);
            debugObject.position = worldPosition;
        }
        
        
        /*var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out Hit))
        {
            pointer = Hit.transform;
        }
        */
        //Debug.Log(worldPosition);
    }
}
