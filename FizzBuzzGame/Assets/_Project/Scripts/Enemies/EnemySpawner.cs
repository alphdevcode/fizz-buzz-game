using AlphDevCode.Tools;
using UnityEngine;
using UnityEngine.Pool;


namespace AlphDevCode.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        private readonly SpawnBoundary _spawnBoundary = new SpawnBoundary();
        private IObjectPool<Enemy> _enemyPool;

        private const float SpawnRate = 1f;

        private void Awake()
        {
            _enemyPool = new ObjectPool<Enemy>(
                CreateEnemy,
                OnGetEnemy,
                OnReleaseEnemy,
                OnDestroyEnemy,
                maxSize: 10);
        }

        private Enemy CreateEnemy()
        {
            Enemy enemy = Instantiate(enemyPrefab);
            enemy.SetPool(_enemyPool);
            return enemy;
        }

        private void OnGetEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(true);
            enemy.MoveToPlayer();
            enemy.SetEnemyType();
        }

        private void OnReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
        }

        private void OnDestroyEnemy(Enemy enemy)
        {
            Destroy(enemy.gameObject);
        }

        private void Start()
        {
            InvokeRepeating(
                nameof(SpawnEnemyAtRandomPosition),
                SpawnRate,
                SpawnRate);
        }

        private void SpawnEnemyAtRandomPosition()
        {
            var point = _spawnBoundary.GetRandomSpawnPoint();
            var enemy = _enemyPool.Get();
            enemy.SetPosition(new Vector3(point.x, 0, point.y));
        }
    }
}