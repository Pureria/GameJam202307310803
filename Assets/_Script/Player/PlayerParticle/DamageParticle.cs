using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageParticle : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle1;

    [SerializeField]
    private ParticleSystem particle2;

    public void PlayParticle()
    {
        particle1.Play();
        particle2.Play();
    }
}
