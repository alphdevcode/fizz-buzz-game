using AlphDevCode.ScriptableObjects;

namespace AlphDevCode.Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(EnemyTypeScriptableObject enemyTypeData);
    }
}