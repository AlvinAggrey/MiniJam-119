using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeUI : MonoBehaviour
{

    [SerializeField] CanvasGroup m_canvasGroup;
    [SerializeField] float m_fadeRate = 0.05f;   
    bool m_fadeIn = false;

    public void FadeIn()
    {
        m_fadeIn = true;
        m_canvasGroup.alpha = 0;
    }
    public void FadeOut()
    {
        m_fadeIn = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_fadeIn && m_canvasGroup.alpha < 1)
        {
            m_canvasGroup.alpha += m_fadeRate;
        }
        else if (!m_fadeIn && m_canvasGroup.alpha < 0)
        {
            m_canvasGroup.alpha -= m_fadeRate;
        }
    }
}
