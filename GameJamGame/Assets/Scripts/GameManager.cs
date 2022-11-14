using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player m_player;
    [SerializeField] GameObject m_posEndScreen;
    [SerializeField] GameObject m_negEndScreen;
    [SerializeField] GameObject m_EndScreen;
    DefaultInputActions.UIActions uiActions;

    bool showPosEnd = false;
    bool showNegEnd = false;
    bool showEndScreen = false;



    // Start is called before the first frame update
    void Start()
    {
        m_EndScreen.SetActive(false);
        m_posEndScreen.SetActive(false);
        m_negEndScreen.SetActive(false);

        uiActions = new DefaultInputActions.UIActions();
        uiActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_player.IsLose)
        {
            if(showEndScreen == true)
            {
                m_EndScreen.SetActive(true);
            }
            else if((int)m_player.MobMentalState() > 0)
            {
                m_EndScreen.SetActive(true);
                if(uiActions.Click.IsPressed())
                {
                    showEndScreen = true;
                    m_negEndScreen.SetActive(false);
                }
            }
            else if((int)m_player.MobMentalState() < 0)
            {
                m_EndScreen.SetActive(true);
                if (uiActions.Click.IsPressed())
                {
                    showEndScreen = true;
                    m_negEndScreen.SetActive(false);
                }
            }
        }
    }
}
