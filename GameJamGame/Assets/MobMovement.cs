using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MobMovement : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_spriteRenderer;
    public Transform m_destination;
    public bool m_isMoving;
    [SerializeField] NavMeshAgent m_agent;
    float m_walkRadius = 1;
    Vector3 m_randomDirection;
    Vector3 m_targetPosition;
    Vector3 m_prev_targetPosition;
    bool m_isArrived;
    float m_directionFacing;

    // Start is called before the first frame update
    void Start()
    {
        m_targetPosition = ChoosePosition();
    }

    Vector3 ChoosePosition()
    {
        m_randomDirection = Random.insideUnitCircle * m_walkRadius;
        m_randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(m_randomDirection, out hit, m_walkRadius, 1);
        Vector3 targetPosition = hit.position;
        return targetPosition;
    }
    // Update is called once per frame
    void Update()
    {

        if (m_isMoving && m_isArrived == true)
        {
            m_targetPosition = ChoosePosition();
            m_isArrived = m_agent.SetDestination(m_targetPosition);
        }
        else if (m_isMoving && m_isArrived == false)
        {
            m_isArrived = m_agent.SetDestination(m_targetPosition);
        }

        float directionFacing = (m_targetPosition - transform.position).x;
        if (directionFacing > 0)
        {
            m_spriteRenderer.flipX = true;
        }
        else if (directionFacing < 0)
        {
            m_spriteRenderer.flipX = false;
        }

    }
}
