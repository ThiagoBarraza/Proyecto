using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    [SerializeField] GameObject ExplodesOnImpact;
    [HideInInspector] PMovement PM;
    [SerializeField] int Damage;
    void Start()
    {
        if (ExplodesOnImpact)
        {
            PM = FindObjectOfType<PMovement>();
        }
        
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Ground" && col.gameObject.tag != "Ammo" && col.gameObject.tag != "EnemyBullet")
        {
            if (ExplodesOnImpact)
            {
                Vector3 Contacto = col.contacts[0].point;
                Instantiate(ExplodesOnImpact, Contacto, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(gameObject.tag != "Ammo")
        {
            if (col.gameObject.tag == "Player")
            {
                PM.ActualHP -= Damage;
            }
        }
    }
}