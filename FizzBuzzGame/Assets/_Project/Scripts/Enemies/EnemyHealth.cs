using System;
using System.Collections;
using System.Security.Cryptography;
using AlphDevCode.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace AlphDevCode.Enemies
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyHealth : MonoBehaviour, IDamageable, IDieable
    {
        private const float SinkSpeed = 2.5f;
        private bool _isDead = false;

        public void TakeDamage()
        {
            if (_isDead) return;

            Die();
        }

        public void Die()
        {
            _isDead = true;
            if(TryGetComponent(out NavMeshAgent navMeshAgent)) navMeshAgent.enabled = false;
            if (TryGetComponent(out Rigidbody rb)) rb.isKinematic = true;
            
            GetComponent<BoxCollider>().enabled = false;
            
            var sinker = new Sinker(transform);
            StartCoroutine(sinker.SinkDown(SinkSpeed, 5f, () => { Destroy(gameObject); }));
        }
        
    }
}