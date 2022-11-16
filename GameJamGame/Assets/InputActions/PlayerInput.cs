using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerActions m_playerAction;
    [SerializeField] InputAction mouseClick;
    [SerializeField] InputAction mousePosition;
    void Awake()
    {
        m_playerAction = new PlayerActions();
    }
    void OnEnable()
    {
        m_playerAction.Enable();
        //mouseClick.Enable();
        //mousePosition.Enable();
        m_playerAction.Gun.Shoot.started += Shoot_performed;
    }
    //void hjgklah(InputAction.CallbackContext obj)
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(mousePosition.ReadValue<Vector3>());
    //}
    //private void MouseClick_performed(InputAction.CallbackContext obj)
    //{
    //    throw new System.NotImplementedException();
    //}

    private void Shoot_performed(InputAction.CallbackContext obj)
    { 
        Ray ray = Camera.main.ScreenPointToRay(m_playerAction.Gun.MousePosition.ReadValue<Vector2>());

        RaycastHit hit;

        Physics.Raycast(ray, out hit);

        if (hit.collider != null)
        {
            Mob hitMob = hit.collider.gameObject.GetComponent<Mob>();
            if (hitMob != null)
            {
                hitMob._Mind._EmotionValue._Value = 0;
            }
        }

    }

    private void Update()
    {
        
    }
    private void OnDisable()
    {
       // m_playerAction.Disable();
        mouseClick.Disable();
        mousePosition.Disable();
    }
}
