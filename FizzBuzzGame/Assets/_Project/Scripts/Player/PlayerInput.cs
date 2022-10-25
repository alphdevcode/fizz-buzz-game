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
        private WeaponSwitching _weaponSwitching;

        private void Awake()
        {
            _rotation = GetComponent<Rotation>();
            _weapon = GetComponentInChildren<Weapon>();
        }

        private void Start()
        {
            _weaponSwitching = _weapon.GetComponent<WeaponSwitching>();
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
                _weaponSwitching.NextWeapon();
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                _weaponSwitching.PreviousWeapon();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _weaponSwitching.ChangeWeapon(FizzBuzzLogicType.DUMB);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _weaponSwitching.ChangeWeapon(FizzBuzzLogicType.FIZZ);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _weaponSwitching.ChangeWeapon(FizzBuzzLogicType.BUZZ);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _weaponSwitching.ChangeWeapon(FizzBuzzLogicType.FIZZBUZZ);
            }
        }
    }
}