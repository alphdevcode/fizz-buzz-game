using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform _player;
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _player = GameObject.FindWithTag("Player").transform;
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            _navMeshAgent.SetDestination(_player.position);
            
        }
    }
}