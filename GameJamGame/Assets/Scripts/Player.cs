using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float m_health = 5;
    public Emotion m_mentality;
    public Emotion m_mobMentality;
    public List<Emotion> m_emotions;

    public Image m_image;
    public List<Sprite> m_Sprites;

    bool m_isLose = false;

    float[] negativeBand = { -1, -2 };
    float[] positiveBand = { 1, 2 };

    public bool IsLose { get { return m_isLose; } }
    public bool MobMentaltiy { get { return m_mobMentality; } }

    public void Heal(float num)
    {
        m_health += num;
    }
    public void Damage(float num)
    {
        m_health -= num;
    }

    float CalcAverage()
    {
        float average = 0;
        for (int i = 0; i < m_emotions.Count; i++)
        {
            average += m_emotions[i]._EmotionValue._Value;
        }

        average = (average / m_emotions.Count);
        return average;
    }

    void CheckMentality()
    {
        if(m_mentality.EmotionState == EmotionState.Neutral)
        {
            m_image.sprite = m_Sprites[0];
        }
        else if (m_mentality.EmotionState > EmotionState.Neutral)
        {
            m_image.sprite = m_Sprites[1];
        }
        else if (m_mentality.EmotionState < EmotionState.Neutral)
        {
            m_image.sprite = m_Sprites[2];
        }
    }

    //-2 to 2 range
    public EmotionState emotionBand(float num)
    {
        EmotionState band = EmotionState.Neutral;
        //negative
        if (num <= negativeBand[1])
        {
            band = EmotionState.ExNegative;
        }
        else if (num > negativeBand[1] && num < negativeBand[0])
        {
            band = EmotionState.Negative;
        }
        //positive
        if (num < positiveBand[1] && num > positiveBand[0])
        {
            band = EmotionState.Positive;

        }
        else if (num >= positiveBand[1])
        {
            band = EmotionState.EXPositive;
        }
        //neutral band
        else if (num > negativeBand[0] && num < positiveBand[0])
        {
            band = EmotionState.Neutral;
        }
        return band;
    }
    public EmotionState MobMentalState()
    {
        return emotionBand(CalcAverage());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        CheckMentality();
        //lose Conditions
        if(CalcAverage()> 2)
        {
            m_isLose = true;
        }
        else if (CalcAverage()< -2)
        {
            m_isLose = true;
        }
        else if (m_health <= 0)
        {
            m_isLose = true;
        }

    }
}