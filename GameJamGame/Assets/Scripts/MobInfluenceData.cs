using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MobInfluence", menuName = "ScriptableObjects/InfluenceData")]
public class MobInfluenceData : ScriptableObject
{
    [Header("Amount of Influence")]
    public float Neutral;
    public float Positive;
    public float EXPositive;
    public float Negative;
    public float EXNegative;
}
