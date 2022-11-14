using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//stores floating point value of emotional state
public class EmotionValue
{
    int m_min;
    int m_max;
    [SerializeField] float m_value = 0;
    public float _Value { get { return m_value; } set { m_value = value; CheckValue(); } }

    public EmotionValue(int value)
    {
        m_min = -2;
        m_max = 2;
        m_value = value;

        CheckValue();
    }
    void CheckValue()
    {
        if (m_value > m_max)
        {
            m_value = m_max;
        }
        else if (m_value < m_min)
        {
            m_value = m_max;
        }
    }
    public void Increase(float num)
    {
        m_value += num;

        CheckValue();
    }
    public void Decrease(float num)
    {
        m_value -= num;

        CheckValue();
    }
    public void Reset()
    {
        m_value = 0;
    }
}
