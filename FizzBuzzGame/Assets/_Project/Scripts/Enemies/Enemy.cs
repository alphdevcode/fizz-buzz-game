using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using AlphDevCode.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

namespace AlphDevCode.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyTypeSelectorScriptableObject enemyTypeSelector;
        [SerializeField] private EnemyTypeScriptableObject enemyType;

        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] private NavMeshAgentMovement movement;
        [SerializeField] private TMP_Text fizzBuzzNumberText;

        private IObjectPool<Enemy> _enemyPool;
        private readonly FizzBuzzLogic _fizzBuzzLogic = new();

        public EnemyTypeScriptableObject EnemyType
        {
            get => enemyType;
            set => enemyType = value;
        }

        public NavMeshAgentMovement Movement => movement;

        public TMP_Text FizzBuzzNumberText
        {
            get => fizzBuzzNumberText;
            set => fizzBuzzNumberText = value;
        }

        public void SetPool(IObjectPool<Enemy> enemyPool)
        {
            _enemyPool = enemyPool;
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
            SetEnemyTypeData(enemyTypeSelector.GetEnemyData(enemyTypeName), fizzBuzzNumber);
        }

        public void SetEnemyTypeData(EnemyTypeScriptableObject enemyData, int fizzBuzzNumber = 0)
        {
            this.enemyType = enemyData;
            InitializeEnemyData(fizzBuzzNumber);
        }

        private void InitializeEnemyData(int fizzBuzzNumber)
        {
            movement.transform.localScale = Vector3.one * enemyType.scaleMultiplier;
            movement.SetSpeed(this.enemyType.movementSpeed);
            skinnedMeshRenderer.material.SetColor(ShaderMaterialHelper.TintColorID, this.enemyType.color);
            if (fizzBuzzNumberText != null)
                fizzBuzzNumberText.text = $"{fizzBuzzNumber}";
        }

        private void MoveToPlayer()
        {
            movement.MoveToDestination(GameObject.FindWithTag("Player").transform.position);
        }

        public void ReleaseFromPool()
        {
            _enemyPool.Release(this);
        }
    }
}