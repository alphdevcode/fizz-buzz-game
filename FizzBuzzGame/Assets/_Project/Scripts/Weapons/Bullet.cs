using AlphDevCode.Interfaces;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using UnityEngine;
using UnityEngine.Pool;

namespace AlphDevCode.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private EnemyTypeScriptableObject _targetEnemyType;
        
        private float _speed = 1;
        private Vector3 _direction = Vector3.forward;
        
        private readonly Movement _movement = new Movement();
        private IObjectPool<Bullet> _bulletPool;
        
        public Vector3 Direction { set => _direction = value; }

        public void SetPool(IObjectPool<Bullet> pool)
        {
            _bulletPool = pool;
        }

        public void SetData(WeaponScriptableObject weaponData)
        {
            _targetEnemyType = weaponData.targetEnemyType;
            SetColor(weaponData.targetEnemyType.color);
            _speed = weaponData.bulletSpeed;
        }

        private void SetColor(Color color)
        {
            if(TryGetComponent<MeshRenderer>(out var meshRenderer))
            {
                meshRenderer.material.color = color;
            }
        }

        private void Update()
        {
            _movement.Move(transform, _direction, _speed);
        }

        private void OnBecameInvisible()
        {
            if (gameObject.activeInHierarchy)
                _bulletPool.Release(this);
        }

        private void OnTriggerEnter(Collider hitCollider)
        {
            if (hitCollider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_targetEnemyType);
            }
            _bulletPool.Release(this);
        }
    }
}