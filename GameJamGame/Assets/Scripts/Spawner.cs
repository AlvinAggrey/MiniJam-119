using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int m_num;
    [SerializeField] List<GameObject> m_mobs;
    [SerializeField] List<Transform> m_spawns;

    [SerializeField] GameObject m_prefab;

    public List<GameObject> Mobs;

    // Start is called before the first frame update
    void Start()
    {
        int spawnNum = m_spawns.Count;
        int spawnIndex = 0;
        for (int i = 0; i < m_num; i++)
        {
            m_mobs.Add(GameObject.Instantiate<GameObject>(m_prefab, m_spawns[spawnIndex]));
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
