using System;
using AlphDevCode.Interfaces;
using AlphDevCode.ScriptableObjects;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable, IDieable
    {
        private const int MaxHealth = 50;

        public event Action OnHealthChange;
        public int CurrentHealth { get; private set; }

        private void Awake()
        {
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(EnemyTypeScriptableObject enemyTypeData)
        {
            CurrentHealth -= enemyTypeData.CalculateDamageToPlayer();
            OnHealthChange?.Invoke();

            if (CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            GetComponent<PlayerInput>().enabled = false;
        }
        
        
    }
}