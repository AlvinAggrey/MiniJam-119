using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour
{

    [SerializeField] private Image barImage;
    private void Start()
    {
        barImage.fillAmount = .0f;
    }
    public void setFillAmount(float fillValue)
    {
        barImage.fillAmount = fillValue;
    }
}



