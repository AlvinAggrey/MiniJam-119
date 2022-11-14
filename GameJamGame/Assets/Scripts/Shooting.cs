using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    PlayerActions inputActionMap;
    // Start is called before the first frame update
    void Start()
    {
        inputActionMap = new PlayerActions();
        inputActionMap.Enable();
        inputActionMap.Gun.Shoot.Enable();
        inputActionMap.Gun.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        Vector2 position = inputActionMap.Gun.Position.ReadValue<Vector2>();
        //Ray ray = Camera.main.ScreenPointToRay(position);
        //RaycastHit hit;
        //Physics.Raycast(ray, out hit);

        //hit.transform.gameObject.GetComponent<Emotion>()._EmotionValue._Value = 0;
        //Debug.Log(hit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
