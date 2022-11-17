using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MobMovement : MonoBehaviour
{
    [SerializeField] SpriteRenderer m_spriteRenderer;
    public Transform m_destination;
    public bool m_isEnabled;
    [SerializeField] NavMeshAgent m_agent;
    [SerializeField] float m_walkRadius;
    Vector3 m_randomDirection;
    [SerializeField] Vector3 m_targetPosition;
    Vector3 m_prev_targetPosition;
    bool m_isArrived;
    float m_directionFacing;
    
    float m_timer = 0;
    float m_standingTimer = 0;


    [SerializeField] float m_maxWalkTime = 1;
    [SerializeField] float m_actualWalkTime = 1;
    [SerializeField] float m_standingTime = 2;
    //[SerializeField] bool m_isIdle = false;
    bool m_standing = false;

    public bool Standing { get { return m_standing; } }

    Vector3 ChoosePosition()
    {
        Vector2 randUnitCircle = Random.insideUnitCircle * new Vector2(Random.Range(1, 1.5f), Random.Range(1, 1.5f));
        
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
        m_timer = 0;
    }


    // Update is called once per frame
    void Update()
    {

        //movement enabled
        if (m_isEnabled)
        {
            if ((m_targetPosition - transform.position).magnitude < 2 || m_timer < 0)
            {
                m_targetPosition = ChoosePosition();
                m_actualWalkTime = m_maxWalkTime * Random.Range(0.5f, 1);
                m_timer = m_actualWalkTime;
                m_standing = true;
            }

            //stand around for a while
            if (m_standing)
            {
                EnableBrakes();
                m_standingTimer -= Time.deltaTime;
                if(m_standingTimer < 0)
                {
                    m_standing = false;
                    m_standingTimer = m_standingTime;
                    DisableBrakes();
                }
            }
            else 
            {
                m_timer -= Time.deltaTime;
                if (m_timer > 0)
                {
                    m_agent.SetDestination(m_targetPosition);
                }
     

                //flip Sprite
                if ((m_targetPosition - transform.position).x > 0)
                {
                    m_spriteRenderer.flipX = true;
                }
                else if ((m_targetPosition - transform.position).x < 0)
                {
                    m_spriteRenderer.flipX = false;
                }
            }
        }

        void EnableBrakes()
        {
            m_agent.velocity = Vector3.zero;
            m_agent.isStopped = false;

        }
        void DisableBrakes()
        {
            m_agent.isStopped = false;
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
