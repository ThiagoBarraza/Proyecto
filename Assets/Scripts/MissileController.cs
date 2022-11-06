using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class MissileController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    Vector3 Target;
    GameObject CameraTestEmpty;
    public CameraTest CT;
    public float RotationSpeed;
    public float TrackTime;
    public float StopTrack;
    [SerializeField] GameObject Xplosion;
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
        if (col.gameObject.tag != "GAU" && col.gameObject.tag != "Ammo" && col.gameObject.tag != "EnemyBullet" && col.gameObject.tag != "Rocket")
        {
            Vector3 Contacto = col.contacts[0].point;
            Instantiate(Xplosion, Contacto, Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(2f, 10f, 0f, 3f);
            Destroy(gameObject);
        }
    }
}