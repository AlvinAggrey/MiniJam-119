using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Influence : MonoBehaviour
{
    //[SerializeField]SphereCollider m_radius;
    [SerializeField] protected float m_influenceNum;
    //influence rate
    [SerializeField] protected float m_seconds = 1;
    protected Mind m_mind;

    List<TriggerTimeLog> m_mindLog;

    // Start is called before the first frame update
    void Awake()
    {
        m_mind = GetComponent<Mind>();
        m_mindLog = new List<TriggerTimeLog> ();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != this)
        {
            Mind targetEmotion = other.GetComponent<Mind>();
            if (targetEmotion != null && targetEmotion.enabled
                && this.GetComponent<Collider>() != other && other.isTrigger)
            {
                TriggerTimeLog entry = new TriggerTimeLog(other.gameObject);
                m_mindLog.Add(entry);
            }
        }

    }

    private void OnTriggereExit(Collider other)
    {
        //remove from Log on exit

        //int index = m_triggerLog.BinarySearch(other.gameObject);

        //if (index >= 0)
        //{
        //    m_triggerLog.RemoveAt(index);
        //}
        for (int i = 0; i < m_mindLog.Count; i++)
        {
            if (m_mindLog[i]._GameObject == other)
            {
                m_mindLog.RemoveAt(i);
            }
        }
    }

    void InfluenceOthers()
    {
        //influence mobs after x time
        for (int i = 0; i < m_mindLog.Count; i++)
        {
            m_mindLog[i].Step();
            Mind targetEmotion = m_mindLog[i]._GameObject.GetComponent<Mind>();
            if (targetEmotion != null && targetEmotion.enabled
            && m_mindLog[i].Duration >= m_seconds)
            {
                Debug.Log("start time:" + m_mindLog[i].LogTime + "end time:" + Time.time);
                targetEmotion._EmotionValue._Value += m_influenceNum;
                m_mindLog[i].LogCurrentTime();
            }    
        }
    }
    // Update is called once per frame
    void Update()
    {
        InfluenceOthers();
    }
}
