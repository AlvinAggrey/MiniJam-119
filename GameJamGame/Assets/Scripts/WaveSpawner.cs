using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : Spawner
{
    //in seconds
    [SerializeField] int numPerWave = 5;
    [SerializeField] float waveTimer = 20;
    [SerializeField] GameObject m_prefab;
    float countDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0)
        {
            Spawn(m_prefab, numPerWave);
            countDown = waveTimer;
        }
    }
}
