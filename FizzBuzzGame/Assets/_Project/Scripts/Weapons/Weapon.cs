using System;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using UnityEngine;
using UnityEngine.VFX;

namespace AlphDevCode.Weapons
{
    public class Weapon : MonoBehaviour
    {
        public WeaponScriptableObject weaponScriptableObject;
        
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bulletPrefab;

        private float _shootingInterval;
        private float _reloadTimer;
        private MovementRb _movementRb;

        public bool IsShooting { get; set; }

        private void Start()
        {
            _shootingInterval = weaponScriptableObject.shootingInterval;
            _movementRb = new MovementRb();
        }

        public void Shoot()
        {
            if(_reloadTimer > 0 || !IsShooting) return;

            _reloadTimer = _shootingInterval;
            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            _movementRb.MoveForwardRb(bullet, firePoint.forward, 20f);
        }
        
       private void Update()
        {
            _reloadTimer -= Time.deltaTime;
            Shoot();
        }
    }
}