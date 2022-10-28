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
        [SerializeField] private EnemyAnimation enemyAnimator;
        [SerializeField] private Rigidbody enemyRigidbody;
        [SerializeField] private NavMeshAgent enemyNavMeshAgent;
        private const float SinkSpeed = 1.2f;
        public bool IsDead { get; private set; }
        public Enemy Enemy
        {
            set => enemy = value;
        }

        public static event Action<int> OnDie;

        public void TakeDamage(EnemyTypeScriptableObject enemyTypeData)
        {
            if (IsDead) return;

            if (enemyTypeData == enemy.EnemyType)
                Die();
        }

        public void Die()
        {
            if(enemyAnimator) enemyAnimator.Die();
            OnDie?.Invoke(enemy.EnemyType.GetFizzBuzzLogicValue());
            ActivateEnemy(false);
    
            if (!enemyNavMeshAgent) return;
            var sinker = new Sinker(enemyNavMeshAgent.transform);
            StartCoroutine(sinker.SinkDown(SinkSpeed, 3f, 1f,
                () => { enemy.ReleaseFromPool(); }));
        }

        private void ActivateEnemy(bool active)
        {
            IsDead = !active;
            if (enemyRigidbody) enemyRigidbody.isKinematic = !active;
            if (enemyNavMeshAgent) enemyNavMeshAgent.enabled = active;
            GetComponent<BoxCollider>().enabled = active;
            if (enemy) enemy.FizzBuzzNumberText.enabled = active;
        }

        private void OnEnable()
        {
            ActivateEnemy(true);
        }
    }
}