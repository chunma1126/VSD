using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour,IPlayerComponent
{
   private Player Player;
   
   [SerializeField] private ParticleSystem[] slashEffect;
   
   public void PlaySlashEffect(int index)
   {
      slashEffect[index].Simulate(0);
      slashEffect[index].Play();
   }

   public void Initialize(Player _player)
   {
      Player = _player;
   }
}
