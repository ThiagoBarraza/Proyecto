using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource Sound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MuteMusic()
    {
        if(Sound.mute == true)
        {
            Sound.mute = true;
        }
        else
        {
            Sound.mute = false;
        }
    }
}
