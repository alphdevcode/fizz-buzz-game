using System;
using UnityEngine;
using UnityEngine.AI;

namespace AlphDevCode.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        private Transform _player;
        private NavMeshAgentMovement _navMeshAgentMovement;

        private void Awake()
        {
            _player = GameObject.FindWithTag("Player").transform;
            _navMeshAgentMovement = GetComponent<NavMeshAgentMovement>();

        }

        void Start()
        {
            _navMeshAgentMovement.MoveTo(_player.position);
        }
    }
}