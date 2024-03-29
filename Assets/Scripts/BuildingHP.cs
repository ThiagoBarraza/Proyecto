﻿using System.Collections;
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

    //Materials

    [SerializeField] Material DefaultMat;
    [SerializeField] Material DamageMaterial;

    Renderer rend;

    //Models

    [SerializeField] GameObject[] Models;

    //Fire

    [SerializeField] ParticleSystem Fire;
    bool Onfire = false;

    //Points awarded once destroyed

    public int Reward;

    //Conection to the main points manager script

    public PMovement PM;

    //Particle systema istantiated when destroyed

    [SerializeField] GameObject DeathSystem;

    //

    [SerializeField] float MatTime = 0.09f;
    float ActualMatTime;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        PM = GameObject.FindObjectOfType<PMovement>();
        Health = MaxHealth;
        if (DBuilding)
        {
            DBuilding.SetActive(false);
        }
        ActualMatTime = MatTime;
        DefaultMat = Models[0].GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        PM = FindObjectOfType<PMovement>();

        if (Models[0].GetComponent<Renderer>().material != DefaultMat)
        {
            if(ActualMatTime > 0)
            {
                ActualMatTime -= Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < Models.Length; i++)
                {
                    Models[i].GetComponent<Renderer>().material = DefaultMat;
                }

                ActualMatTime = MatTime;
            }
        }

        if (Health <= MaxHealth / 2 && Onfire == false && Fire)
        {
            Fire.Play();
            Onfire = true;
        }

        if (Health <= 0)
        {
            PM.Points += Reward;
            if (DeathSystem)
            {
                Instantiate(DeathSystem, gameObject.transform.position, Quaternion.identity);
            }
            if (DBuilding)
            {
                DBuilding.SetActive(true);
                DBuilding.transform.parent = null;
            }
            gameObject.SetActive(false);
            for (int e = 0; e < Models.Length; e++)
            {
                Models[e].SetActive(false);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ammo")
        {
            for (int i = 0; i < Models.Length; i++)
            {
                Models[i].GetComponent<Renderer>().material = DamageMaterial;
            }

            Health--;

            Debug.Log("Remaining health: " + Health);
        }

        if (col.gameObject.tag == "Rocket")
        {
            //Health -= 15;

            Debug.Log("Remaining health" + Health);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Hammo"))
        {
            Health -= 15;

            Debug.Log("Hit");
        }
    }
}