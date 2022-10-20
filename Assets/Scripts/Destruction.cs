using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField] float Time;
    [SerializeField] GameObject Trigg;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
