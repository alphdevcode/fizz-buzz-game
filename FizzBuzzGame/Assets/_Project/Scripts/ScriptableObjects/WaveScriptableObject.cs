using UnityEngine;

namespace AlphDevCode.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New EnemyWave", menuName = "EnemyWave")]
    public class WaveScriptableObject : ScriptableObject
    {
        public int enemiesAmount = 20;
        public float spawnRate = 1f;
    }
}