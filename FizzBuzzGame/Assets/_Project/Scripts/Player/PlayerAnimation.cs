using System;
using AlphDevCode.Managers;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Weapons;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private RangeAttack playerRangeAttack;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private EnemySpawner enemySpawner;

        private readonly int _animDieHash = Animator.StringToHash("Die");
        private readonly int _animGetHitHash = Animator.StringToHash("GetHit");
        private readonly int _animAttackHash = Animator.StringToHash("Attack");
        private readonly int _animChangeAttackTypeHash = Animator.StringToHash("ChangeAttackType");
        private readonly int _animVictoryHash = Animator.StringToHash("Victory");
        private readonly int _animReviveHash = Animator.StringToHash("Revive");

        private void OnEnable()
        {
            playerHealth.OnDie += Die;
            playerHealth.OnRevive += Revive;
            playerRangeAttack.OnAttack += Attack;
            enemySpawner.OnWaveCompleted += Victory;
            playerHealth.OnDamageReceived += GetHit;
            playerRangeAttack.OnWeaponChange += ChangeAttackType;
        }

        private void Revive()
        {
            playerAnimator.SetTrigger(_animReviveHash);
        }

        private void Victory()
        {
            playerAnimator.SetTrigger(_animVictoryHash);
        }
        
        private void Die()
        {
            playerAnimator.SetTrigger(_animDieHash);
        }

        private void GetHit()
        {
            playerAnimator.SetTrigger(_animGetHitHash);
        }

        private void Attack()
        {
            playerAnimator.SetTrigger(_animAttackHash);
        }

        private void ChangeAttackType(WeaponScriptableObject weapon)
        {
            playerAnimator.SetTrigger(_animChangeAttackTypeHash);
        }
        
        private void OnDisable()
        {
            playerHealth.OnDie -= Die;
            playerHealth.OnRevive -= Revive;
            playerRangeAttack.OnAttack -= Attack;
            enemySpawner.OnWaveCompleted -= Victory;
            playerHealth.OnDamageReceived -= GetHit;
            playerRangeAttack.OnWeaponChange -= ChangeAttackType;
        }
    }
}