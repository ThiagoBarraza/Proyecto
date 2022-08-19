using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PMovement : MonoBehaviour
{
    
    //Variables
    
    public float ZSpeed; //Moving forward speed
    public float XSpeed; //Moving backwards 
    public float ActualHP; 
    public float MaxHP;
    public float AddedRotation = 90;

    public int Points = 0;
    public Text PointText;

    //Resources

    public GameObject Weapon;
    Rigidbody rb;
    public CameraTest CT;
    public GameObject Model;

    // Start is called before the first frame update
    void Start()
    {
        ActualHP = MaxHP;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ActualHP < 1)
        {
            Destroy(gameObject);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, ZSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -ZSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(XSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-XSpeed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Habilidad();
        }

        Vector3 lookPos = CT.worldPosition - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY + AddedRotation, 0);
        Model.transform.rotation = rotation;

        PointText.text = "Ptos: " + Points;
    }

    private void Habilidad()
    {
        Debug.Log("Rockets");
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "EnemyBullet")
        {
            ActualHP--;
        }
    }
}
