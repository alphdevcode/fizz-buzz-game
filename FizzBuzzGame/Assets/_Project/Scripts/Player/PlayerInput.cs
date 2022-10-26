using System;
using AlphDevCode.Tools;
using AlphDevCode.Weapons;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Rotation _rotation;
        private Weapon _weapon;
        private WeaponSwitcher _weaponSwitcher;

        private void Awake()
        {
            _rotation = GetComponent<Rotation>();
            _weapon = GetComponentInChildren<Weapon>();
        }

        private void Start()
        {
            _weaponSwitcher = _weapon.GetComponent<WeaponSwitcher>();
        }

        private void Update()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

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