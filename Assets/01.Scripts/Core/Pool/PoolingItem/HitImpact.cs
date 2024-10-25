using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HitImpact : Poolable
{
    [SerializeField] private VisualEffect _visualEffect;
    [SerializeField] private float activeTime;
    private float timer = 0;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > activeTime)
        {
            PoolManager.Instance.Push(this);
        }
    }

    public override void ResetItem()
    {
        timer = 0;
       _visualEffect.Simulate(0);
    }
}
