using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;

namespace AlphDevCode.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyTypeSelectorScriptableObject enemyTypeSelector;
        [SerializeField] private EnemyTypeScriptableObject enemyType;

        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private TMP_Text fizzBuzzNumberText;

        private IObjectPool<Enemy> _enemyPool;
        private readonly FizzBuzzLogic _fizzBuzzLogic = new FizzBuzzLogic();

        public EnemyTypeScriptableObject EnemyType => enemyType;

        public void SetPool(IObjectPool<Enemy> enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public void SetPosition(Vector3 position)
        {
            navMeshAgent.Warp(position);
        }

        public void Initialize()
        {
            GetRandomEnemyType();
            MoveToPlayer();
        }

        private void GetRandomEnemyType()
        {
            var fizzBuzzNumber = _fizzBuzzLogic.GetRandomNumber();
            var enemyTypeName = _fizzBuzzLogic.EvaluateNumber(fizzBuzzNumber);
            SetEnemyTypeData(enemyTypeSelector.GetEnemyData(enemyTypeName),fizzBuzzNumber);
        }

        public void SetEnemyTypeData(EnemyTypeScriptableObject enemyData, int fizzBuzzNumber = 0)
        {
            this.enemyType = enemyData;
            InitializeEnemyData(fizzBuzzNumber);
        }

        private void InitializeEnemyData(int fizzBuzzNumber)
        {
            navMeshAgent.speed = this.enemyType.movementSpeed;
            meshRenderer.material.color = this.enemyType.color;
            fizzBuzzNumberText.text = $"{fizzBuzzNumber}";
        }

        private void MoveToPlayer()
        {
            navMeshAgent.SetDestination(
                GameObject.FindWithTag("Player").transform.position);
        }

        public void ReleaseFromPool()
        {
            _enemyPool.Release(this);
        }
    }
}