using System;
using AlphDevCode.Weapons;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Rotation _rotation;
        private Weapon _weapon;

        private void Awake()
        {
            _rotation = GetComponent<Rotation>();
            _weapon = GetComponentInChildren<Weapon>();
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
        }
    }
}