using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHP : MonoBehaviour
{

    //Destroyed building model

    public GameObject DBuilding;

    //HP amount

    public int MaxHealth;

    //HP

    int Health;

    //Fire

    public ParticleSystem Fire;
    bool Onfire = false;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        DBuilding.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= MaxHealth / 2)
        {
            if (Onfire == false)
            {
                Fire.Play();
                Onfire = true;
            }
        }
        
        if(Health <= 0)
        {
            DBuilding.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ammo")
        {
            Health--;

            Debug.Log("Remaining health: " + Health);
        }

        if(col.gameObject.tag == "Rocket")
        {
            Health -= 15;
        }
    }
}
