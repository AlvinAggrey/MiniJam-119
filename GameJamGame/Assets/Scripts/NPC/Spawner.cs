using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int m_num;
    [SerializeField] List<GameObject> m_mobs;
    [SerializeField] List<Transform> m_spawns;

    [SerializeField] GameObject m_prefab;
    [SerializeField] float[] chances = {0.2f,0.2f,0.2f,0.2f,0.2f};

    public List<GameObject> Mobs { get { return m_mobs; } }

    void Start()
    {
        int spawnNum = m_spawns.Count;
        int spawnIndex = 0;
        GameObject instance = m_prefab;
        for (int i = 0; i < m_num; i++)
        {
            int emotionValue = Random.Range(-2, 2);
            instance.GetComponent<Mind>()._EmotionValue._Value = emotionValue;
            m_mobs.Add(GameObject.Instantiate<GameObject>(instance, m_spawns[spawnIndex]));
            spawnIndex++;
            if(spawnIndex >= spawnNum)
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
