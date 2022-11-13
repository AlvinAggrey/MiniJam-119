using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] Emotion m_emotion;

    // Start is called before the first frame update
    void Start()
    {
        m_emotion = gameObject.AddComponent<Emotion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}