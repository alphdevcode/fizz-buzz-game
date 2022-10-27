using System;
using AlphDevCode.Interfaces;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace AlphDevCode.Enemies
{
    [RequireComponent(typeof(BoxCollider))]
    public class EnemyHealth : MonoBehaviour, IDamageable, IDieable
    {
        [SerializeField] private Enemy enemy;
        private const float SinkSpeed = 2.5f;
        private bool _isDead = false;

        public static event Action<int> OnEnemyDie;

        public void TakeDamage(EnemyTypeScriptableObject enemyTypeData)
        {
            if (_isDead) return;

            if (enemyTypeData == enemy.EnemyType)
                Die();
        }

        public void Die()
        {
            OnEnemyDie?.Invoke(enemy.EnemyType.GetFizzBuzzLogicValue());
            ActivateEnemy(false);
            
            var sinker = new Sinker(transform);
            StartCoroutine(sinker.SinkDown(SinkSpeed, 5f, 
                () => { enemy.ReleaseFromPool(); }));
        }

        private void ActivateEnemy(bool active)
        {
            _isDead = !active;
            if (TryGetComponent(out Rigidbody rb)) rb.isKinematic = !active;
            if(TryGetComponent(out NavMeshAgent navMeshAgent)) navMeshAgent.enabled = active;
            GetComponent<BoxCollider>().enabled = active;
        }

        private void OnEnable()
        {
            ActivateEnemy(true);
        }
    }
}