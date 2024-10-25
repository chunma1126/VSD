using System;
using UnityEngine;
using UnityEngine.VFX;

public class EffectFeedback : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystem;
    [SerializeField] private VisualEffect[] _visualEffect;
    
    public void PlayFeedback()
    {
        foreach (var t in _particleSystem)
        {
            t.Simulate(0);
            t.Play();
        }

        foreach (var t in _visualEffect)
        {
            t.Simulate(0);
            t.Play();
        }
        
        
    }
}