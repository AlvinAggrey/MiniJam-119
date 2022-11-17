using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] Mind m_mind;
    public Animator animator;
    public MobMovement m_movement;
    [SerializeField] Collider m_radius;
    int count = 0;

    [SerializeField] float m_decay;
    public bool isWalking = false;
    bool influenced;

    public Mind _Mind { get { return m_mind; } }
    //animator field names
    string anim_emotionState = "EmotionState";
    string anim_isWalking = "isWalking";


    // Start is called before the first frame update
    void Start()
    {
        //m_emotion = gameObject.AddComponent<Emotion>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Influence>()._Mind.EmotionState != EmotionState.Neutral)
        {
            count++;
            influenced = true;
        };
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<Influence>()._Mind.EmotionState != EmotionState.Neutral)
        {
          count--;
        };
        if (count <= 0)
        {
            influenced = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (m_movement.Standing)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        if(!influenced)
        {
            switch (m_mind.EmotionState)
            {
                case EmotionState.Positive:
                    m_decay -= m_decay;
                    break;
                case EmotionState.Negative:
                    m_decay -= m_decay;
                    break;
            }
        }

        animator.SetBool(anim_isWalking, isWalking);
        animator.SetInteger(anim_emotionState, (int)m_mind.EmotionState);
    }
}