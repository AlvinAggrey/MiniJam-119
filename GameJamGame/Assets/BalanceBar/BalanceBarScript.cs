using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceBarScript : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] private Image barImageHeaven;
    [SerializeField] private Image barImageHell;
    private void Start()
    {
        barImageHeaven.fillAmount = 0.5f;
        barImageHell.fillAmount = 0.5f;
    }
    public void setFillAmount(float fillValue)
    {
        if (fillValue < 0)
            return;
        try
        {
            barImageHeaven.fillAmount = fillValue;
            barImageHell.fillAmount =  1 - fillValue;
        }
        catch
        {
            barImageHeaven.fillAmount = 1;
            barImageHell.fillAmount =  1 - 1;

        }

    }

    public void Update()
    {
        float fillAmount = (gameManager.WorldMindState._EmotionValue._Value + 2) / 5;
        setFillAmount(fillAmount);
    }
}

