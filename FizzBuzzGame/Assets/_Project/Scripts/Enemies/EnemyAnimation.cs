using AlphDevCode.Player;
using AlphDevCode.ScriptableObjects;
using UnityEngine;

namespace AlphDevCode.Enemies
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator enemyAnimator;
        [SerializeField] private EnemyAttack enemyAttack;
        private PlayerHealth _playerHealth;

        private readonly int _animDieHash = Animator.StringToHash("Die");
        private readonly int _animAttackHash = Animator.StringToHash("Attack");
        private readonly int _animVictoryHash = Animator.StringToHash("Victory");

        private void Awake()
        {
            _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        }

        private void OnEnable()
        {
            enemyAttack.OnEnemyNearPlayer += Attack;
            if (_playerHealth)
                _playerHealth.OnDie += Victory;
        }

        private void Victory()
        {
            enemyAnimator.SetTrigger(_animVictoryHash);
        }

        public void Die()
        {
            enemyAnimator.SetTrigger(_animDieHash);
        }

        private void Attack()
        {
            enemyAnimator.SetTrigger(_animAttackHash);
        }

        private void OnDisable()
        {
            enemyAttack.OnEnemyNearPlayer -= Attack;
            if (_playerHealth)
                _playerHealth.OnDie -= Victory;
        }
    }
}