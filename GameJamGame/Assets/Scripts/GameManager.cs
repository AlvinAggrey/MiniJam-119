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
    [SerializeField] Mind m_worldMindState;
    [SerializeField] GameObject m_posEndScreen;
    [SerializeField] GameObject m_negEndScreen;
    [SerializeField] GameObject m_EndScreen;
    DefaultInputActions m_inputActions;

    [SerializeField] bool isLose;

    [SerializeField] public bool IsLose {get{return true;}}
    public Action<EmotionState> OnLose;

    bool showEndScreen = false;

    public Mind WorldMindState { get{return m_worldMindState;}}

    // Start is called before the first frame update
    void Start()
    {
        m_EndScreen.SetActive(false);
        m_posEndScreen.SetActive(false);
        m_negEndScreen.SetActive(false);
        m_inputActions = new DefaultInputActions();
        m_inputActions.Enable();

        //m_player.OnDeath += Lose;
    }
    void Lose(EmotionState state)
    {
        OnLose?.Invoke(state);
        //m_player.OnDeath -= Lose;
    }

    float CalcAverageMindState()
    {
        float average = 0;
        List<GameObject> mobs = m_spawner.Mobs;
        for (int i = 0; i < mobs.Count; i++)
        {
            average += mobs[i].GetComponent<Mind>()._EmotionValue._Value;
        }
        return average /= mobs.Count;
    }
    // Update is called once per frame
    void Update()
    {
        m_worldMindState._EmotionValue._Value = CalcAverageMindState();
        if (m_worldMindState.EmotionState == EmotionState.EXNegative)
        {
            Lose(EmotionState.EXNegative);
        }
        else if (m_worldMindState.EmotionState == EmotionState.EXPositive)
        {
            Lose(EmotionState.EXPositive);
        }
    }
}
