using System;
using AlphDevCode.Managers;
using AlphDevCode.ScriptableObjects;
using AlphDevCode.Tools;
using AlphDevCode.Utilities;
using UnityEngine;
using UnityEngine.Pool;

namespace AlphDevCode.Weapons
{
    public class RangeAttack : MonoBehaviour
    {
        [SerializeField] private WeaponScriptableObject weaponData;

        [SerializeField] private Transform firePoint;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform bulletsContainer;
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

        private float _shootingInterval;

        private float _reloadTimer;
        private IObjectPool<Bullet> _bulletPool;
        
        public bool IsAttacking { get; set; }
        public WeaponScriptableObject WeaponType => weaponData;
        public event Action<WeaponScriptableObject> OnWeaponChange;
        public event Action OnAttack;

        public void SetData(WeaponScriptableObject weaponTypeData)
        {
            if (weaponData == weaponTypeData) return;

            weaponData = weaponTypeData;
            OnWeaponChange?.Invoke(weaponTypeData);
            AudioSystem.instance.PlaySoundAtPoint("ChangeAttack", transform.position);
            InitializeData();
        }

        private void InitializeData()
        {
            _shootingInterval = weaponData.shootingInterval;
            skinnedMeshRenderer.material.SetColor(ShaderMaterialHelper.TintColorID, weaponData.targetEnemyType.color);
        }

        private void Awake()
        {
            _bulletPool = new ObjectPool<Bullet>(
                CreateBullet,
                OnGetBullet,
                OnReleaseBullet,
                OnDestroyBullet,
                maxSize: 10);
        }

        #region PoolMethods

        private Bullet CreateBullet()
        {
            Bullet bullet = Instantiate(bulletPrefab, bulletsContainer);
            bullet.SetPool(_bulletPool);
            return bullet;
        }

        private void OnGetBullet(Bullet bullet)
        {
            bullet.transform.position = firePoint.position;
            bullet.Direction = firePoint.forward;
            bullet.SetData(weaponData);
            bullet.gameObject.SetActive(true);
        }

        private void OnReleaseBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        private void OnDestroyBullet(Bullet bullet)
        {
            Destroy(bullet.gameObject);
        }

        #endregion

        private void Start()
        {
            InitializeData();
        }

        private void Attack()
        {
            if (_reloadTimer > 0 || !IsAttacking) return;

            OnAttack?.Invoke();
            _reloadTimer = _shootingInterval;
            _bulletPool.Get();
            AudioSystem.instance.PlaySoundAtPoint("FireAttack", transform.position);
        }

        private void Update()
        {
            _reloadTimer -= Time.deltaTime;
            Attack();
        }
    }
}