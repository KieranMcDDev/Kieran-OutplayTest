using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObjectParticle : MonoBehaviour
{
    ParticleSystem particle;
    AudioSource source;

    //Retrieve Audio and Particle
    public void Start()
    {
        particle = GetComponent<ParticleSystem>();
        source = GetComponent<AudioSource>();
    }

    //Checks when both the particle effect and audio file has finished playing
    public void Update()
    {
        if(!source.isPlaying && !particle.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
