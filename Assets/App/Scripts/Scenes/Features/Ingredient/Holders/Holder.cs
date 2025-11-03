using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    [field: SerializeField] public HolderAnimator Animator { get; private set; }

    [SerializeField] private ParticleSystem _particles;
    
    public void CreateParticles()
    {
        if (!_particles) return;

        ParticleSystem newEffect = Instantiate(_particles, transform.position, Quaternion.Euler(-90,0,0));

        newEffect.Play();

        float destroyDelay = newEffect.main.duration + newEffect.main.startLifetime.constantMax;
        Destroy(newEffect.gameObject, destroyDelay);
    }
}
