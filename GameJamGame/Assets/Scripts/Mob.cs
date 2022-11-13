using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public Emotion m_emotion;
    public Animator animator;

    public bool isWalking = false;

    //animator field names
    string anim_emotionState = "EmotionState";
    string anim_isWalking = "isWalking";

    // Start is called before the first frame update
    void Start()
    {
        m_emotion = gameObject.AddComponent<Emotion>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetInteger(anim_emotionState, (int)m_emotion.EmotionState);
        animator.SetBool(anim_isWalking, isWalking);
    }
}