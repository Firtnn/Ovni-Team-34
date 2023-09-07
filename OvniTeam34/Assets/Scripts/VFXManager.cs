using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    private ParticleSystemStopBehavior _stopBehavior = ParticleSystemStopBehavior.StopEmittingAndClear;
    [SerializeField] private ParticleSystem _presThinkParticleSystem;

    public void PlayPresThinkFX(bool shouldPlay)
    {
        if (shouldPlay)
        {
            _presThinkParticleSystem.Play();
        }
        else
        {
            _presThinkParticleSystem.Stop(true, _stopBehavior);
        }
    }
}
