using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stat")]
public class PlayerStatSO : ScriptableObject
{
    public Stat statType;
    public float amount;
}