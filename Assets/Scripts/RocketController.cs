using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    Transform Target;
    GameObject Player;
    [SerializeField] GameObject Xplosion;
    //public TurretControl TC;
    public float RotationSpeed;
    public float TrackTime;
    public float StopTrack;
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
        if(TrackTime <= 0 &&  StopTrack > 0)
        {
            StopTrack -= Time.deltaTime;
            var targetRotation = Quaternion.LookRotation(Target.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Ammo" && col.gameObject.tag != "EnemyBullet" && col.gameObject.tag != "Rocket" && col.gameObject.tag != "GAU")
        {
            
            Vector3 Contacto = col.contacts[0].point;
            Instantiate(Xplosion, Contacto, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}