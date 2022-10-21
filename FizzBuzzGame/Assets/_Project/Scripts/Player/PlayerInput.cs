using System;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerRotation _playerRotation;

        private void Awake()
        {
            _playerRotation = GetComponent<PlayerRotation>();
        }

        private void Update()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out var floorHit, 50f, LayerMask.GetMask("Ground")))
            {
                var pointToLook = floorHit.point;

                _playerRotation.LookAtOnlyInYAxis(pointToLook);
            }
        }
    }
}