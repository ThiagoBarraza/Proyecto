using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    private SphereCollider SP;
    private float RTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        SP = transform.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= RTime)
        {
            if(SP.radius < 3.5f)
            {
                SP.radius += 0.5f;
            }
        }
        else
        {

        }   
    }
}
