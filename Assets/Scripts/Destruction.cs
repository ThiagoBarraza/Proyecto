using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField] float Time;
    [SerializeField] GameObject Trigg;
    [SerializeField] bool HasAudio;
    private AudioSource Sound;
    
    private bool Played = false;

    // Update is called once per frame
    void Start()
    {
        if (HasAudio)
        {
            Sound = GetComponent<AudioSource>();
        }
    }
    
    void Update()
    {


        if (!Trigg)
        {
            
            Destroy(gameObject, Time);
            if (Sound && !Played)
            {
                Sound.Play();
                Played = true;
            }
        }
        else
        {
            if (!Trigg.activeInHierarchy)
            {
                Destroy(gameObject);
                
            }
        }
        
    }
}
