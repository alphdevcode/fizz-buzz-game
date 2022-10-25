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


        public void SetPool(IObjectPool<Enemy> enemyPool)
        {
            _enemyPool = enemyPool;
        }

        public void SetPosition(Vector3 position)
        {
            navMeshAgent.Warp(position);
        }

        public void MoveToPlayer()
        {
            navMeshAgent.SetDestination(
                GameObject.FindWithTag("Player").transform.position);
        }

        public void SetEnemyTypeData()
        {
            var fizzBuzzNumber = _fizzBuzzLogic.GetRandomNumber();
            var enemyTypeName = _fizzBuzzLogic.EvaluateNumber(fizzBuzzNumber);
            this.enemyType = enemyTypeSelector.GetEnemyData(enemyTypeName);

            InitializeEnemyData(fizzBuzzNumber);
        }

        private void InitializeEnemyData(int fizzBuzzNumber)
        {
            navMeshAgent.speed = this.enemyType.movementSpeed;
            meshRenderer.material.color = this.enemyType.color;
            fizzBuzzNumberText.text = $"{fizzBuzzNumber}";
        }

        public void ReleaseFromPool()
        {
            _enemyPool.Release(this);
        }
    }
}