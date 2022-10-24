using System;
using System.Collections;
using System.Security.Cryptography;
using AlphDevCode.Interfaces;
using AlphDevCode.ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

namespace AlphDevCode.Enemies
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyHealth : MonoBehaviour, IDamageable, IDieable
    {
        [SerializeField] private Enemy enemy;
        private const float SinkSpeed = 2.5f;
        private bool _isDead = false;

        private void OnEnable()
        {
            ActivateEnemy(true);
        }

        public void TakeDamage()
        {
            if (_isDead) return;

            Die();
        }

        public void Die()
        {
            ActivateEnemy(false);
            
            var sinker = new Sinker(transform);
            StartCoroutine(sinker.SinkDown(SinkSpeed, 5f, () => { enemy.ReleaseFromPool(); }));
        }

        private void ActivateEnemy(bool active)
        {
            _isDead = !active;
            if (TryGetComponent(out Rigidbody rb)) rb.isKinematic = !active;
            if(TryGetComponent(out NavMeshAgent navMeshAgent)) navMeshAgent.enabled = active;
            GetComponent<BoxCollider>().enabled = active;
        }
        
    }
}