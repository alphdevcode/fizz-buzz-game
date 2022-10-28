using System;
using AlphDevCode.Interfaces;
using AlphDevCode.ScriptableObjects;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable, IDieable
    {
        private const int MaxHealth = 50;

        public event Action OnDamageReceived;
        public event Action OnDie;
        public event Action OnRevive;
        public int CurrentHealth { get; private set; }

        public void Revive()
        {
            CurrentHealth = MaxHealth;
            OnRevive?.Invoke();
        }

        private void Awake()
        {
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(EnemyTypeScriptableObject enemyTypeData)
        {
            CurrentHealth -= enemyTypeData.GetFizzBuzzLogicValue();
            OnDamageReceived?.Invoke();

            if (CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            OnDie?.Invoke();
        }
    }
}