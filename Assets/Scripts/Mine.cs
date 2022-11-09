using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    Animator Anim;
    [SerializeField] float DetoTime;
    [SerializeField] ParticleSystem DeathSystem;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim.GetBool("Active") && DetoTime > 0)
        {
            DetoTime -= Time.time;
        }
        else if(Anim.GetBool("Active") && DetoTime < 0)
        {
            Instantiate(DeathSystem, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Anim.SetBool("Active", true);
        }
    }
}
