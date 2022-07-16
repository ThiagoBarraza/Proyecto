using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    
    
    //Variables
    
    public float ZSpeed; //Moving forward speed
    public float XSpeed; //Moving backwards 
    public int vidas; //Player lives, might get reworked
    public int NroVidas; //Amount of lives, will get reworked
    
    

    //Resources

    Rigidbody rb;
    public CameraTest CT;
    public GameObject Model;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CT = FindObjectOfType<CameraTest>();
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, ZSpeed * .2f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -ZSpeed * .2f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(XSpeed * .2f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-XSpeed * .2f, 0, 0);
        }

        //Model.transform.LookAt(CT.worldPosition); whole model "looksat", while i only want the y axis

        Vector3 lookPos = CT.worldPosition - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY + 90, 0);
        Model.transform.rotation = rotation ;
    }
    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Ground")
        {
            
        }

        if (col.gameObject.name == "DeathWall")
        {
            vidas--;
        }
    }

    void OnCollisionExit()
    {
        
    }

    void OnCollisionStay(Collision col)
    {
        
    }
}
