using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int MaxShots = 5;
    [SerializeField] float shotRegenCooldown = 2;
    float m_regenTimer = 2;
    string compTag = "Mob";

    int Shots = 5;
    bool m_canShoot = true;
    [SerializeField] float shotCooldown = 2;
    float m_shotCooldownTimer = 0;

    PlayerActions m_playerAction;

    void Awake()
    {
        m_playerAction = new PlayerActions();
    }
    void OnEnable()
    {
        m_playerAction.Enable();
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
        if (m_canShoot == false)
        {
            return;
        }
        audioSource.PlayOneShot(shootSound);
        Ray ray = Camera.main.ScreenPointToRay(m_playerAction.Gun.MousePosition.ReadValue<Vector2>());

        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        
        if (hit.collider != null && hit.collider.CompareTag(compTag))
        {
            Mob hitMob = hit.collider.gameObject.GetComponent<Mob>();
            if (hitMob != null)
            {
                audioSource.clip = hitSound;
                audioSource.PlayDelayed(0.3f);
                //audioSource.clip = null;
                hitMob._Mind._EmotionValue._Value = 0;
                m_shotCooldownTimer = shotCooldown;
                m_canShoot = false;
                Shots--;
                Debug.DrawLine(ray.origin, hit.point, Color.green,5f);
            }
        }
        
    }

    private void Update()
    {

        if (Shots < MaxShots)
        {
            m_regenTimer -= Time.deltaTime;
            if(m_regenTimer <= 0)
            {
                Shots++;
                m_regenTimer = shotRegenCooldown;
            }
        }

        if(m_canShoot == false)
        {
            m_shotCooldownTimer -= Time.deltaTime;
            if(m_shotCooldownTimer <= 0)
            {
                m_canShoot = true;
                m_shotCooldownTimer = shotCooldown;
            }
        }
        text.text = Shots.ToString();
    }
    private void OnDisable()
    {
        m_playerAction.Disable();
        m_playerAction.Gun.Shoot.started -= Shoot_performed;
    }
}
