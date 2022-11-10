using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water1 : MonoBehaviour
{
    [SerializeField] Vector3 PosInicial;

    
    [SerializeField] float speed;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * -3;
        gameObject.transform.position = new Vector3(PosInicial.x , y -1, PosInicial.z);
    }
}