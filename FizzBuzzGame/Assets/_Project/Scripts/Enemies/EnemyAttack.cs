using System;
using AlphDevCode.Interfaces;
using AlphDevCode.Managers;
using UnityEngine;

namespace AlphDevCode.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;

        public event Action OnEnemyNearPlayer;

        private void OnTriggerEnter(Collider hitCollider)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                OnEnemyNearPlayer?.Invoke();
            }
        }

        public void Attack(IDamageable health)
        {
            health.TakeDamage(enemy.EnemyType);
            enemy.ReleaseFromPool();
            AudioSystem.instance.PlaySoundAtPoint("SlimeAttack", transform.position);
        }
    }
}