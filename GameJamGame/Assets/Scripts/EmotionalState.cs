using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmotionState
{
    ExNegative = -2,
    Negative,
    Neutral,
    Positive,
    EXPositive,
}

public struct EmotionValue
{
    int min = -2;
    int max = 2;
    float value = 0;

    void Increase(float num)
    {
        value += num;

        if (value > max)
        {
            value = 0;
        }
    }
    void Decrease(float num)
    {
        value -= num;

        if (value < min)
        {
            value = 0;
        }
    }
    void Reset()
    {
        value = 0;
    }
}
