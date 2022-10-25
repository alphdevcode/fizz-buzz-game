using System;
using PlasticGui.WorkspaceWindow.QueryViews.Changesets;
using UnityEngine;
using UnityEngine.AI;

namespace AlphDevCode.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshAgentMovement : MonoBehaviour
    {
        private Transform _player;
        private NavMeshAgent _navMeshAgent;

        public void MoveTo(Vector3 point)
        {
            _navMeshAgent.SetDestination(point);
        }

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").transform;
        }

        private void OnEnable()
        {
            // MoveTo(_player.position);
        }
    }
}