using System;
using UnityEngine;
using UnityEngine.AI;

namespace AlphDevCode.Enemies
{
    [RequireComponent(typeof(NavMeshAgentMovement))]
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
            // _navMeshAgentMovement.MoveTo(_player.position);
        }

        private void OnEnable()
        {
            // _navMeshAgentMovement.MoveTo(_player.position);
        }
    }
}