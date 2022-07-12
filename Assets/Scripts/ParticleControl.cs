using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem Particulas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartP()
    {
        Particulas.Play();
    }

    public void StopP()
    {
        Particulas.Stop();
    }

    public void PauseP()
    {
        Particulas.Pause();
    }

    public void ClearP()
    {
        Particulas.Clear();
    }
}
