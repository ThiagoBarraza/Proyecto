using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHability : MonoBehaviour
{
    [SerializeField] GameObject Missile;
    [SerializeField] Transform[] MissileSpawn;
    public float Cooldown;
    public float ActualCooldown;
    public CameraTest CT;
    public Vector3 Target;
    
    // Start is called before the first frame update
    void Start()
    {
        ActualCooldown = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        CT = FindObjectOfType<CameraTest>();

        if(ActualCooldown > 0)
        {
            ActualCooldown -= Time.deltaTime;
        }
        if (ActualCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                for (int i = 0; i < MissileSpawn.Length; i++)
                {
                    Instantiate(Missile, MissileSpawn[i].position, MissileSpawn[i].rotation);
                    ActualCooldown = Cooldown;
                }
            }
        }
    }
}
