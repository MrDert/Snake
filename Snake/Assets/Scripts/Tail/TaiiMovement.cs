using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TaiiMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private TailNetwork _tail;
    void Update()
    {
        _agent.speed = _tail.Owner.Speed;
        _agent.SetDestination(_tail.TailTarget.transform.position);
    }
}
