using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField] float Time;
    [SerializeField] GameObject Trigg;
    
    // Update is called once per frame
    void Update()
    {
        if (!Trigg)
        {
            Destroy(gameObject, Time);
        }
        else
        {
            if (!Trigg.activeInHierarchy)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
