using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Emotion : MonoBehaviour
{
    [SerializeField] EmotionState m_emotionState;
    [SerializeField] EmotionValue m_emotionValue;

    float[] negativeBand = { -1, -2};
    float[] positiveBand = { 1, 2 };

    private void OnEnable()
    {
        m_emotionState = EmotionState.Neutral;
        m_emotionValue = new EmotionValue(0);
    }

    public EmotionState EmotionState { get { return m_emotionState; } }
    public EmotionValue _EmotionValue{ get { return m_emotionValue; }}

    public void Increase(float num)
    {
        m_emotionValue.Increase(num);
    }
    public void Decrease(float num)
    {
        m_emotionValue.Decrease(num);
    }
    public void _Reset()
    {
        m_emotionValue.Reset();
    }
    void CheckBand()
    {
        //negative
        if (m_emotionValue._Value <= negativeBand[1])
        {
            m_emotionState = EmotionState.ExNegative;
        }
        else if (m_emotionValue._Value > negativeBand[1] && m_emotionValue._Value < negativeBand[0])
        {
            m_emotionState = EmotionState.Negative;

        }
        //positive
        if (m_emotionValue._Value < positiveBand[1] && m_emotionValue._Value > positiveBand[0])
        {
            m_emotionState = EmotionState.Positive;

        }
        else if (m_emotionValue._Value >= positiveBand[1])
        {
            m_emotionState = EmotionState.EXPositive;
        }
        //neutral band
        else if (m_emotionValue._Value > negativeBand[0] && m_emotionValue._Value < positiveBand[0])
        {
            m_emotionState = EmotionState.Neutral;
        }
    }
    private void Update()
    {
        CheckBand();
    }

}