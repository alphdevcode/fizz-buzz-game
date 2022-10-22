using System;
using PlasticGui.WorkspaceWindow.QueryViews.Changesets;
using UnityEngine;
using UnityEngine.AI;

namespace AlphDevCode.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshAgentMovement : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 point)
        {
            _navMeshAgent.SetDestination(point);
        }
    }
}