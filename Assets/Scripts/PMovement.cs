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

    public CameraTest CT;
    [SerializeField] private GameObject Model;
    public bool Defeated;

    public Pause PS;

    // Start is called before the first frame update
    void Start()
    {
        ActualHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (PS.gameIsPaused)
        {
            
        }
        else
        {
            Model.SetActive(true);
        }
        
        if (ActualHP < 1)
        {
            Model.SetActive(false);
            Defeated = true;
            PS.gameIsPaused = true;
        }

        if (PS.gameIsPaused)
        {
            
        }
        else
        {
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
        }

        

        PointText.text = "" + Points;
    }

    void OnCollisionEnter(Collision col)
    {
        string colision = col.gameObject.tag;

        switch (colision)
        {
            case "EnemyBullet":
                ActualHP--;
                break;
            case "TankAmmo":
                ActualHP -= 5;
                break;
            case "Thunder":
                ActualHP -= 3;
                break;
            case "DeathWall":
                ActualHP -= 100;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string Tcolision = other.gameObject.tag;

        switch (Tcolision)
        {
            case "Thunder":
                ActualHP -= 3;
                break;
        }
    }
}
