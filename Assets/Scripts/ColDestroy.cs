using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDestroy : MonoBehaviour
{
    [SerializeField] GameObject GameBundle;
    [SerializeField] ParticleSystem DeathSystem;
    


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if (DeathSystem)
            {
                Instantiate(DeathSystem, gameObject.transform);
            }
            
            if (GameBundle)
            {
                Destroy(GameBundle);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
