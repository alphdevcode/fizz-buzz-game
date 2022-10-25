using System;
using AlphDevCode.Enemies;
using AlphDevCode.Interfaces;
using AlphDevCode.Tools;
using UnityEngine;
using UnityEngine.Pool;

namespace AlphDevCode.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private float _speed = 1;
        private Vector3 _direction = Vector3.forward;
        
        private readonly Movement _movement = new Movement();
        private IObjectPool<Bullet> _bulletPool;

        public void SetPool(IObjectPool<Bullet> pool)
        {
            _bulletPool = pool;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void SetColor(Color color)
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
            if (hitCollider.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage();
            }
            _bulletPool.Release(this);
        }
    }
}