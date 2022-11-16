using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public Mind m_mind;
    public Animator animator;
    public MobMovement m_movement;

    public bool isWalking = false;

    //animator field names
    string anim_emotionState = "EmotionState";
    string anim_isWalking = "isWalking";

    // Start is called before the first frame update
    void Start()
    {
        //m_emotion = gameObject.AddComponent<Emotion>();
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

        animator.SetBool(anim_isWalking, isWalking);
        animator.SetInteger(anim_emotionState, (int)m_mind.EmotionState);
    }
}