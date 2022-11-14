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
