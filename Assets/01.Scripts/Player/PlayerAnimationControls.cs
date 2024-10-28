using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControls : MonoBehaviour,IPlayerComponent
{
    private Player player;
    
    public void Initialize(Player _player)
    {
        player = _player;
    }
    
    private void AnimationEnd()
    {
        player.AnimationEndTrigger();
    }

    private void PlaySlashEffect()
    {
        player.PlaySlashEffect();
    }

    private void DamageCast()
    {
        player.DamageCast();
    }

 
}
