using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimeLog
{
    float m_time;
    float m_duration;
    GameObject m_gameObject;

    public float LogTime { get { return m_time; } }
    public float Duration { get { return m_duration; } }
    public GameObject _GameObject { get { return m_gameObject; } }

    public TriggerTimeLog(GameObject go)
    {
        m_gameObject = go;
        m_time = Time.time;
        m_duration = 0;
    }
    //calculating duration
    public void Step()
    {
        m_duration = Time.time - m_time;
    }
    public void LogCurrentTime()
    {
        m_time = Time.time;
        m_duration = 0;
    }
}
