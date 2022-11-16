using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float m_health = 5;
    
    public Spawner m_spawner;

    public Image m_image;
    public List<Sprite> m_Sprites;
    
    [SerializeField] GameManager m_GameManager;
    bool m_isDead = false;
    
    public event EventHandler OnDeath;

    public bool IsLose { get { return m_isDead; } }

    public void Heal(float num)
    {
        m_health += num;
    }
    public void Damage(float num)
    {
        m_health -= num;
    }


    void ChangeEmotionalState(EmotionState state)
    {

        if (state == EmotionState.Neutral)
        {
            m_image.sprite = m_Sprites[0];
        }
        else if (state > EmotionState.Neutral)
        {
            m_image.sprite = m_Sprites[1];
        }
        else if (state < EmotionState.Neutral)
        {
            m_image.sprite = m_Sprites[2];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_GameManager.WorldMindState.OnChangeEmotion += ChangeEmotionalState;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_health <= 0)
        {
            m_isDead = true;
            OnDeath?.Invoke(this, EventArgs.Empty);
        }

    }
}
