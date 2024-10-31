using System;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    Damage,
    AttackSpeed,
    MoveSpeed,
    DodgeSpeed,
    Defense,
    CriticalPercent,
}

public class PlayerStatManager : MonoBehaviour,IPlayerComponent
{
    private Player Player;
    
    private Dictionary<Stat, float> PlayerStats = new Dictionary<Stat, float>();
    public List<PlayerStatSO> addStatList = new List<PlayerStatSO>();
    
    private void Start()
    {
        foreach (var item in addStatList)
        {
            AddStat(item);
        }
    }
    
    public void AddStat(PlayerStatSO statSo)
    {
        if (PlayerStats.ContainsKey(statSo.statType))
        {
            PlayerStats[statSo.statType] += statSo.amount;
        }
        else
        {     
            PlayerStats.Add(statSo.statType , statSo.amount);
        }
    }

    public void RemoveStat(PlayerStatSO statSo)
    {
        if (PlayerStats.ContainsKey(statSo.statType) == false)
        {
            Debug.LogError("없는 스탯을 빼려고 합니다.");
            return;
        }

        PlayerStats[statSo.statType] -= statSo.amount;
    }
    
    
    
    public float GetStat(Stat stat)
    {
        float amount = 0;
        foreach (var item in PlayerStats)
        {
            if (stat == item.Key)
            {
                amount += item.Value;
            }
        }
        
        return amount;
    }


    public void Initialize(Player _player)
    {
        Player = _player;
    }
}
