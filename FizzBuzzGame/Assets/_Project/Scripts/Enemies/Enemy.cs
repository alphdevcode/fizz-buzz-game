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

        public void SetEnemyType()
        {
            var fizzBuzzNumber = _fizzBuzzLogic.GetRandomNumber();
            var enemyTypeName = _fizzBuzzLogic.EvaluateNumber(fizzBuzzNumber);
            this.enemyType = enemyTypeSelector.GetEnemyByTypeName(enemyTypeName);

            InitializeEnemyData(fizzBuzzNumber);
        }

        private void InitializeEnemyData(int fizzBuzzNumber)
        {
            navMeshAgent.speed = this.enemyType.movementSpeed;
            meshRenderer.material.color = this.enemyType.enemyColor;
            fizzBuzzNumberText.text = $"{fizzBuzzNumber}";
        }

        private void OnValidate()
        {
            gameObject.name = $"{this.enemyType.enemyName} Enemy";
        }

        public void ReleaseFromPool()
        {
            _enemyPool.Release(this);
        }
    }
}