using System;
using AlphDevCode.Player;
using UnityEngine;

namespace AlphDevCode.Enemies
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyAttack enemyAttack;

        private void OnTriggerEnter(Collider hitCollider)
        {
            if (hitCollider.TryGetComponent(out PlayerHealth playerHealth))
            {
                enemyAttack.Attack(playerHealth);
            }
        }
        
    }
}