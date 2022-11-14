using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Influence : MonoBehaviour
{
    [SerializeField]SphereCollider m_radius;

    [SerializeField] Emotion m_emotion;
    // Start is called before the first frame update
    void Start()
    {
        m_emotion = GetComponent<Emotion>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Emotion>() != null && m_radius != other)
        {
            other.GetComponent<Emotion>()._EmotionValue._Value += m_emotion._EmotionValue._Value/6000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
