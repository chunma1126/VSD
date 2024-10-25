using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct ActionData
{
    public ActionData(Vector3 normal, Vector3 hitPoint, float damageAmount, float force)
    {
        this.normal = normal;
        this.hitPoint = hitPoint;
        this.damageAmount = damageAmount;
        this.force = force;
    }
    
    public Vector3 normal;
    public Vector3 hitPoint;
    
    public float damageAmount;
    public float force;
}
