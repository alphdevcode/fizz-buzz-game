using AlphDevCode.Player;
using UnityEngine;

namespace AlphDevCode.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;

        private void OnTriggerEnter(Collider hitCollider)
        {
            if (hitCollider.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(enemy.EnemyType);
                enemy.ReleaseFromPool();
            }
        }
        
    }
}