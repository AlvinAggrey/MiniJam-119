using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobInfluence : Influence
{
    [SerializeField] MobInfluenceData m_data;
    [SerializeField] Mind m_mind;
    
    void CheckMindState(EmotionState emotion)
    {
        switch(m_mind.EmotionState)
        {
            case EmotionState.Neutral:
                m_influenceNum = m_data.Neutral;
                break;
            case EmotionState.Positive:
                m_influenceNum = m_data.Positive;
                break;
            case EmotionState.EXPositive:
                m_influenceNum = m_data.EXPositive;
                break;
            case EmotionState.Negative:
                m_influenceNum = m_data.Negative;
                break;

            case EmotionState.EXNegative:
                m_influenceNum = m_data.EXNegative;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_mind.OnChangeEmotion += CheckMindState;
    }
}
