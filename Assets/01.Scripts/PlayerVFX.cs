using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
   [SerializeField] private ParticleSystem[] slashEffect;
   
   public void PlaySlashEffect(int index)
   {
      slashEffect[index].Simulate(0);
      slashEffect[index].Play();
   }
   
}
