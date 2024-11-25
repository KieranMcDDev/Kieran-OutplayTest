using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObjectParticle : MonoBehaviour
{
    ParticleSystem particle;
    AudioSource source;

    public void Start()
    {
        particle = GetComponent<ParticleSystem>();
        source = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(!source.isPlaying && !particle.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
