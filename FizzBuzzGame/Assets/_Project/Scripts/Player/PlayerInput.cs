using System;
using AlphDevCode.Tools;
using AlphDevCode.Weapons;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Camera _mainCamera;
        private Rotation _rotation;
        private Weapon _weapon;
        private WeaponSwitcher _weaponSwitcher;

        private bool _blockInput;

        public void BlockInput(bool block)
        {
            _blockInput = block;
        }
        private void Awake()
        {
            _rotation = GetComponent<Rotation>();
            _weapon = GetComponentInChildren<Weapon>();
        }

        private void Start()
        {
            _weaponSwitcher = _weapon.GetComponent<WeaponSwitcher>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (_blockInput) return;
            
            var camRay = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out var floorHit, 50f, LayerMask.GetMask("Ground")))
            {
                var pointToLook = floorHit.point;

                _rotation.LookAtOnlyInYAxis(pointToLook);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                _weapon.IsShooting = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Space))
            {
                _weapon.IsShooting = false;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                _weaponSwitcher.NextWeapon();
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                _weaponSwitcher.PreviousWeapon();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _weaponSwitcher.ChangeWeapon(FizzBuzzLogicType.Dumb);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _weaponSwitcher.ChangeWeapon(FizzBuzzLogicType.Fizz);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _weaponSwitcher.ChangeWeapon(FizzBuzzLogicType.Buzz);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _weaponSwitcher.ChangeWeapon(FizzBuzzLogicType.FizzBuzz);
            }
        }

        private void OnDisable()
        {
            _weapon.IsShooting = false;
        }
    }
}