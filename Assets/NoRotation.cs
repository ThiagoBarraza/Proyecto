using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotation : MonoBehaviour
{
    public PMovement PM;
    // Start is called before the first frame update
    void Start()
    {
        PM = FindObjectOfType<PMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3();
    }
}
