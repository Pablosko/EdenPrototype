using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public float baseValue;
    public float extraflat;
    public float extraPercentage;
    public float extraTotalPercentage;
    public float Value { get { return ((baseValue + extraflat) * (1f + extraPercentage / 100f)) * (1f + extraTotalPercentage / 100f); } }
    public void Add(Stat stat) 
    {
        extraflat += stat.extraflat;
        extraPercentage += stat.extraPercentage;
        extraTotalPercentage += stat.extraTotalPercentage;
    }
    public void Reduce(Stat stat)
    {
        extraflat -= stat.extraflat;
        extraPercentage -= stat.extraPercentage;
        extraTotalPercentage -= stat.extraTotalPercentage;
    }
    public void AddPercentage(float percentage)
    {
        extraPercentage += percentage;
    }
    public void AddMultiplyer(float mult)
    {
        extraPercentage += 100 *(mult - 1);
    }
    public void AddTotalPercentage(float percentage)
    {
        extraTotalPercentage += percentage;
    }
    public void AddTotalMultiplyer(float mult)
    {
        extraTotalPercentage += 100 * (mult - 1);
    }
}
