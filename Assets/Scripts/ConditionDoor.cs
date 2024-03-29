﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDoor : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] char axis;
    [SerializeField] GameObject DoorL;
    [SerializeField] Vector3 DoorLFinalPos;
    [SerializeField] Vector3 DoorRFinalPos;
    [SerializeField] GameObject DoorR;
    [SerializeField] GameObject Trigg;
    void Update()
    {
        if (!Trigg.activeInHierarchy)
        {
            OpenDoors();
        }
    }

    void OpenDoors()
    {
        if (DoorL.transform.position.x > DoorLFinalPos.x)
        {
            DoorL.transform.Translate(-speed, 0, 0);
        }
        if (DoorR.transform.position.x < DoorRFinalPos.x)
        {
            DoorR.transform.Translate(speed, 0, 0);
        }
    }
}
