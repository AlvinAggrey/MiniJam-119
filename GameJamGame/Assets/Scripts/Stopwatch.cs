using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    float startTime; 
    //duration in seconds
    int duration;
    string TimeStamp;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        duration = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        duration = (int)(Time.time - startTime);
        
        TimeStamp = duration.ToString();

        for (int i = TimeStamp.Length; i >= 0; i -= 2)
        {
            TimeStamp.Insert(i, ":");
        }

        text.text = TimeStamp;
    }
}
