using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Vector3 worldPosition;
    public Transform pointer;
    Plane plane = new Plane(Vector3.up, 0);
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(rayo, out distance))
        {
            worldPosition = rayo.GetPoint(distance);
        }
        
        float why;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out Hit))
        {
            pointer = Hit.transform;
        }
        //Debug.Log(worldPosition);
    }
}
