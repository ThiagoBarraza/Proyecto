using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    Transform Target;
    GameObject Player;
    //public TurretControl TC;
    public float RotationSpeed;
    public float TrackTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
        Player = GameObject.FindWithTag("Player");
        Target = Player.transform;
    }

    void Update()
    {
        
        transform.position += transform.forward * speed;
        


        if (TrackTime > 0)
        {
            TrackTime -= Time.deltaTime;
        }
        if(TrackTime <= 0)
        {
            var targetRotation = Quaternion.LookRotation(Target.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Ground" && col.gameObject.tag != "Ammo" && col.gameObject.tag != "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }
}