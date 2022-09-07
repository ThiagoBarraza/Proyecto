using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PMovement : MonoBehaviour
{
    
    //Variables
    
    [SerializeField] private float ZSpeed; //Moving forward speed
    [SerializeField] private float XSpeed; //Moving backwards 
    public float ActualHP; 
    public float MaxHP;
    [SerializeField] private float AddedRotation = 90;

    public int Points = 0;
    public Text PointText;

    //Resources

    Rigidbody rb;
    public CameraTest CT;
    [SerializeField] private GameObject Model;

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

        Vector3 lookPos = CT.worldPosition - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, eulerY + AddedRotation, 0);
        Model.transform.rotation = rotation;

        PointText.text = "Ptos: " + Points;
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "EnemyBullet")
        {
            ActualHP--;
        }

        if (col.gameObject.tag == "Thunder")
        {
            ActualHP -= 3;
        }

        if (col.gameObject.tag == "Explosion")
        {
            ActualHP -= 3;
        }
    }
}
