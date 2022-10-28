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
        private RangeAttack _rangeAttack;
        private WeaponSwitcher _weaponSwitcher;
        private bool _blockInput;

        public void BlockInput(bool block)
        {
            _blockInput = block;
            _rangeAttack.IsAttacking = false;
        }

        private void Awake()
        {
            _rotation = GetComponent<Rotation>();
            _rangeAttack = GetComponentInChildren<RangeAttack>();
        }

        private void Start()
        {
            _weaponSwitcher = _rangeAttack.GetComponent<WeaponSwitcher>();
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (_blockInput) return;

            HandleRotationInput();
            HandleAttackInput();
            HandleWeaponChangeInput();
        }

        private void HandleRotationInput()
        {
            var camRay = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out var floorHit, 50f, LayerMask.GetMask("Ground")))
            {
                var pointToLook = floorHit.point;

                _rotation.LookAtOnlyInYAxis(pointToLook);
            }
        }

        private void HandleAttackInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                _rangeAttack.IsAttacking = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Space))
            {
                _rangeAttack.IsAttacking = false;
            }
        }

        private void HandleWeaponChangeInput()
        {
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
            _rangeAttack.IsAttacking = false;
        }
    }
}