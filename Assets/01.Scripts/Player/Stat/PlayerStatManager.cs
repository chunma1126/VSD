using System;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    Damage,
    AttackSpeed,
    MoveSpeed,
    Defense,
    CriticalPercent,
}

public class PlayerStatManager : MonoBehaviour
{
    private Dictionary<Stat, float> PlayerStats = new Dictionary<Stat, float>();
    public List<PlayerStatSO> addStatList = new List<PlayerStatSO>();
    
    private void Awake()
    {
        foreach (var item in addStatList)
        {
            PlayerStats.Add(item.statType , item.amount);
        }
    }

    public void AddStat(PlayerStatSO statSo)
    {
        PlayerStats.Add(statSo.statType , statSo.amount);
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
    
    
    



}
