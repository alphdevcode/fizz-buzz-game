using System;
using System.Collections;
using AlphDevCode.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace AlphDevCode.Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable, IDieable
    {
        private const float SinkSpeed = 2.5f;
        private bool _isDead = false;
        private Sinker _sinker;

        private void Start()
        {
            _sinker = new Sinker(transform);
        }

        public void TakeDamage()
        {
            if (_isDead) return;

            Die();
        }

        public void Die()
        {
            _isDead = true;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;

            StartCoroutine(_sinker.SinkDown(SinkSpeed, 5f));
        }
    }
}