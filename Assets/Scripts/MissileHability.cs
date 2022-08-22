using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHability : MonoBehaviour
{
    [SerializeField] GameObject Missile;
    [SerializeField] Transform[] MissileSpawn;
    [SerializeField] float Cooldown;
    public CameraTest CT;
    public Vector3 Target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CT = FindObjectOfType<CameraTest>();


        for(int i = 0; i < MissileSpawn.Length; i++)
        {
            var b = Instantiate(Missile, MissileSpawn[i].position, MissileSpawn[i].rotation);
        }


        
    }
}
