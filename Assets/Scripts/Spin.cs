using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    Vector3 v3 = Vector3.zero;
    public float Xspeed;
    public float Yspeed;
    public float Zspeed;
    public float YSrotation;
    public float ZSrotation;
    public float XSrotation;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = v3;
        v3.y = YSrotation;
        v3.z = ZSrotation;
        v3.x = XSrotation;
    }

    // Update is called once per frame
    void Update()
    {
        v3.x += Xspeed * Time.deltaTime;
        v3.y += Yspeed * Time.deltaTime;
        v3.z += Zspeed * Time.deltaTime;

        transform.eulerAngles = v3;
    }
}
