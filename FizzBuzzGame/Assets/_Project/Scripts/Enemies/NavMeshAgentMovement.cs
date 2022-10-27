using System;
using PlasticGui.WorkspaceWindow.QueryViews.Changesets;
using UnityEngine;
using UnityEngine.AI;

namespace AlphDevCode.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshAgentMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;

        public void Stop()
        {
            if(TryGetComponent<Rigidbody>(out var rb))
                rb.isKinematic = true;
            
            if(navMeshAgent.enabled)
                navMeshAgent.isStopped = true;
        }
        
        public void MoveToDestination(Vector3 point)
        {
            if(navMeshAgent.enabled)
                navMeshAgent.SetDestination(point);
        }

        public void SetSpeed(float speed)
        {
            navMeshAgent.speed = speed;
        }

        public bool SetPosition(Vector3 newPosition)
        {
            return navMeshAgent.Warp(newPosition);
        }
    }
}