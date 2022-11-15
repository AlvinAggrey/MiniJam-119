using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using System;
public class LoseScreen : MonoBehaviour
{
    [SerializeField] UnityEvent m_posEnd;
    [SerializeField] UnityEvent m_negEnd;

    [SerializeField] GameManager m_gm;
    // Start is called before the first frame update
    void Start()
    {
        m_gm.OnLose +=  OnLose;       
    }
    void OnLose(EmotionState emotion)
    {
        gameObject.SetActive(true);
        if ((int) emotion > 0)
        {
            m_posEnd.Invoke();
        }
        else
        {
            m_negEnd.Invoke();
        }
        m_gm.OnLose -=  OnLose;       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
