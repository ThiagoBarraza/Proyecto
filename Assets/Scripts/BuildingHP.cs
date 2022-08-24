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

    //Points awarded once destroyed

    public int Reward;

    //Conection to the main points manager script

    public PMovement PM;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PM = GameObject.FindObjectOfType<PMovement>();
        Health = MaxHealth;
        if (DBuilding)
        {
            DBuilding.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        PM = FindObjectOfType<PMovement>();

        if (Health <= MaxHealth / 2 && Onfire == false && Fire)
        {
            Fire.Play();
            Onfire = true;
        }
        
        if(Health <= 0)
        {
            PM.Points += Reward;
            if (DBuilding)
            {
                DBuilding.SetActive(true);
            }
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

            Debug.Log("Remaining health" + Health);
        }
    }
}
