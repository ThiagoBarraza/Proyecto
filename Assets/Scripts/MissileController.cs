using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    Vector3 Target;
    GameObject CameraTestEmpty;
    public CameraTest CT;
    public float RotationSpeed;
    public float TrackTime;
    public float StopTrack;
    void Start()
    {
        Destroy(gameObject, lifeTime);
        CameraTestEmpty = GameObject.FindWithTag("CT");
        CT = FindObjectOfType<CameraTest>();
        Target = CT.worldPosition;
    }

    void Update()
    {

        transform.position += transform.forward * speed;



        if (TrackTime > 0)
        {
            TrackTime -= Time.deltaTime;
        }
        if (TrackTime <= 0 && StopTrack > 0)
        {
            StopTrack -= Time.deltaTime;
            var targetRotation = Quaternion.LookRotation(Target - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Ground" && col.gameObject.tag != "Ammo" && col.gameObject.tag != "EnemyBullet" && col.gameObject.tag != "Rocket")
        {
            Destroy(gameObject);
        }
    }
}