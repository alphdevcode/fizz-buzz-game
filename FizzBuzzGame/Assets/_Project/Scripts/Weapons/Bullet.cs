using System;
using AlphDevCode.Tools;
using UnityEngine;
using UnityEngine.Pool;

namespace AlphDevCode.Weapons
{
    public class Bullet : MonoBehaviour
    {
        private float _speed = 1;
        private Vector3 _direction = Vector3.forward;
        private Movement _movement;
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

        
        private void Start()
        {
            _movement = new Movement();
        }

        private void Update()
        {
            _movement.Move(transform, _direction, _speed);
        }

        private void OnBecameInvisible()
        {
            _bulletPool.Release(this);
        }
    }
}