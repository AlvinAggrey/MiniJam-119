using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    [SerializeField] int m_num;
    [SerializeField] List<GameObject> m_mobs;
    [SerializeField] List<Transform> m_spawns;
    int spawnNum;

    [SerializeField] GameObject m_prefab;
    [SerializeField] float[] chances = {0.2f,0.2f,0.2f,0.2f,0.2f};

    public List<GameObject> Mobs { get { return m_mobs; } }

    void Start()
    {
        spawnNum = m_spawns.Count;
        Spawn(m_prefab, m_num);
    }

    protected void Spawn(GameObject m_prefab, int num)
    {
        System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
        GameObject instance = m_prefab;
        int spawnIndex = 0;

        for (int i = 0; i < num; i++)
        {
            int emotionValue = rand.Next(0, 3);
            instance.GetComponent<Mind>()._EmotionValue._Value = emotionValue;
            m_mobs.Add(GameObject.Instantiate<GameObject>(instance, m_spawns[spawnIndex]));
            spawnIndex++;
            if (spawnIndex >= spawnNum)
            {
                spawnIndex = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
