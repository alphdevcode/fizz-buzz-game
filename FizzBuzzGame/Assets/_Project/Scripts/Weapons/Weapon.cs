using System;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.VFX;

namespace AlphDevCode.Weapons
{
    public class Weapon : MonoBehaviour
    {
        public WeaponScriptableObject weaponScriptableObject;

        [SerializeField] private Transform firePoint;
        [SerializeField] private Bullet bulletPrefab;

        private float _shootingInterval;
        private float _reloadTimer;
        private IObjectPool<Bullet> _bulletPool;

        public bool IsShooting { get; set; }

        private void Awake()
        {
            _bulletPool = new ObjectPool<Bullet>(
                CreateBullet,
                OnGetBullet,
                OnReleaseBullet,
                OnDestroyBullet,
                maxSize: 10);
        }

        private Bullet CreateBullet()
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.SetPool(_bulletPool);
            return bullet;
        }

        private void OnGetBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = firePoint.position;
            bullet.SetSpeed(20f);
            bullet.SetDirection(firePoint.forward);
        }

        private void OnReleaseBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }
        
        private void OnDestroyBullet(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }
        
        private void Start()
        {
            _shootingInterval = weaponScriptableObject.shootingInterval;
        }

        public void Shoot()
        {
            if (_reloadTimer > 0 || !IsShooting) return;

            _reloadTimer = _shootingInterval;
            _bulletPool.Get();
        }

        private void Update()
        {
            _reloadTimer -= Time.deltaTime;
            Shoot();
        }
    }
}