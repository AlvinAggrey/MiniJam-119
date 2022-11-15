using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spawner m_spawner;
    [SerializeField] Player m_player;
    [SerializeField] Emotion m_Emotion;
    [SerializeField] GameObject m_posEndScreen;
    [SerializeField] GameObject m_negEndScreen;
    [SerializeField] GameObject m_EndScreen;
    DefaultInputActions m_inputActions;

    [SerializeField] bool isLose;

    [SerializeField] public bool IsLose {get{return true;}}
    public Action<EmotionState> OnLose;
    //bool showPosEnd = false;
    //bool showNegEnd = false;
    bool showEndScreen = false;



    // Start is called before the first frame update
    void Start()
    {
        m_EndScreen.SetActive(false);
        m_posEndScreen.SetActive(false);
        m_negEndScreen.SetActive(false);
        m_inputActions = new DefaultInputActions();
        m_inputActions.Enable();

        m_player.OnDeath += Lose;
    }
    void Lose(object obj, EventArgs e)
    {
        OnLose?.Invoke(EmotionState.ExNegative);
        m_player.OnDeath -= Lose;
    }

    // Update is called once per frame
    void Update()
    {

        // if(m_player.IsLose)
        // {
        //     if(showEndScreen == true)
        //     {
        //         m_EndScreen.SetActive(true);
        //     }
        //     else if((int)m_player.MobMentalState() > 0)
        //     {
        //         m_EndScreen.SetActive(true);
        //         if(m_inputActions.UI.Click.IsPressed())
        //         {
        //             showEndScreen = true;
        //             m_negEndScreen.SetActive(false);
        //         }
        //     }
        //     else if((int)m_player.MobMentalState() < 0)
        //     {
        //         m_EndScreen.SetActive(true);
        //         if (m_inputActions.UI.Click.IsPressed())
        //         {
        //             showEndScreen = true;
        //             m_negEndScreen.SetActive(false);
        //         }
        //     }
        // }
    }
}
