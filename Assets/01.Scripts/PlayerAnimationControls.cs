using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControls : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private void AnimationEnd()
    {
        player.AnimationEndTrigger();
    }

    private void PlaySlashEffect()
    {
        player.PlaySlashEffect();
    }
}
