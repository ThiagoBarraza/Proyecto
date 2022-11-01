using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDestroy : MonoBehaviour
{
    [SerializeField] GameObject GameBundle;
    [SerializeField] ParticleSystem DeathSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
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
