using AlphDevCode.Interfaces;
using AlphDevCode.ScriptableObjects;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable, IDieable
    {
        private const int MaxHealth = 30;

        public int CurrentHealth { get; private set; }

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(EnemyTypeScriptableObject enemyTypeData)
        {
            CurrentHealth -= enemyTypeData.CalculateDamageToPlayer();
            if (CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            GetComponent<PlayerInput>().enabled = false;
        }
        
        
    }
}