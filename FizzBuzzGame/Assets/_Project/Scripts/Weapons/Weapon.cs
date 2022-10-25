using AlphDevCode.ScriptableObjects;
using UnityEngine;
using UnityEngine.Pool;

namespace AlphDevCode.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponScriptableObject weaponData;

        [SerializeField] private Transform firePoint;
        [SerializeField] private Bullet bulletPrefab;

        private float _shootingInterval;

        private float _reloadTimer;
        private IObjectPool<Bullet> _bulletPool;

        public bool IsShooting { get; set; }

        public void SetData(WeaponScriptableObject weaponTypeData)
        {
            if (weaponData == weaponTypeData) return;
            weaponData = weaponTypeData;
            InitializeData();
        }

        private void InitializeData()
        {
            _shootingInterval = weaponData.shootingInterval;
            GetComponent<MeshRenderer>().material.color = weaponData.targetEnemyType.color;
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

        private Bullet CreateBullet()
        {
            Bullet bullet = Instantiate(bulletPrefab);
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

        private void Start()
        {
            InitializeData();
        }

        private void Shoot()
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