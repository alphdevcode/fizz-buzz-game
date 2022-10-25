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
            _player = GameObject.FindWithTag("Player").transform;
        }

        private void Start()
        {
            // MoveTo(_player.position);
        }

        private void OnEnable()
        {
            MoveTo(_player.position);
        }
    }
}