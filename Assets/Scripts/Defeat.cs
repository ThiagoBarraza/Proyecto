using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    [SerializeField] PMovement PM;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        PM = FindObjectOfType<PMovement>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.Defeated == true)
        {
            Camera.transform.parent = null;
            Destroy(Player);
        }
    }
}
