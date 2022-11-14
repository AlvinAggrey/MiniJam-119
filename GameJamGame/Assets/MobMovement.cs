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
    [SerializeField] float m_walkRadius;
    Vector3 m_randomDirection;
    [SerializeField] Vector3 m_targetPosition;
    Vector3 m_prev_targetPosition;
    bool m_isArrived;
    float m_directionFacing;
    Vector3 ChoosePosition()
    {
        Vector2 randUnitCircle = Random.insideUnitCircle;
        
        m_randomDirection = new Vector3(randUnitCircle.x, 0 , randUnitCircle.y) * (m_walkRadius);
        m_randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 targetPosition = new Vector3();
        NavMesh.SamplePosition(m_randomDirection, out hit, m_walkRadius, -1);
        targetPosition = hit.position;
        targetPosition.y = 0;
        return targetPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_targetPosition = ChoosePosition();
    }


    // Update is called once per frame
    void Update()
    {

        m_isArrived = m_agent.SetDestination(m_targetPosition);
        if (m_targetPosition == transform.position)
        {
            m_targetPosition = ChoosePosition(); 
        }
        //if (m_isMoving && m_isArrived == true)
        //{
        //    m_targetPosition = ChoosePosition();
        //    m_isArrived = m_agent.SetDestination(m_targetPosition);
        //}
        //else if (m_isMoving && m_isArrived == false)
        //{
        //    m_isArrived = m_agent.SetDestination(m_targetPosition);
        //}

        //float directionFacing = (m_targetPosition - transform.position).x;
        //if (directionFacing > 0)
        //{
        //    m_spriteRenderer.flipX = true;
        //}
        //else if (directionFacing < 0)
        //{
        //    m_spriteRenderer.flipX = false;
        //}

    }
}
