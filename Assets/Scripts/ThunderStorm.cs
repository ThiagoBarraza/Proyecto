using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStorm : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] GameObject Thunder;
    [SerializeField] float Cooldown;
    private bool OnRange = false;
    [SerializeField] float Inaccuracy;
    private float InaccuracyCooldown;
    private float ActualCooldown;
    public PMovement PM;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ActualCooldown = Cooldown;
        InaccuracyCooldown = Inaccuracy;
        PM = FindObjectOfType<PMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnRange)
        {
            if(ActualCooldown > 0)
            {
                ActualCooldown -= Time.deltaTime;
            }
            if(ActualCooldown <= 0)
            {
                GameObject player = GameObject.FindWithTag("Player");
                Target = player.transform;
                if(InaccuracyCooldown > 0)
                {
                    InaccuracyCooldown -= Time.deltaTime;
                }
                else
                {
                    Instantiate(Thunder, Target.position, Quaternion.identity);
                    PM.ActualHP -= 3;
                    ActualCooldown = Cooldown;
                }
                
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            OnRange = false;
        }
    }
}
