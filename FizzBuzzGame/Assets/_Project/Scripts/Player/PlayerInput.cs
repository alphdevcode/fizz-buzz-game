using System;
using UnityEngine;

namespace AlphDevCode.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Rotation _rotation;

        private void Awake()
        {
            _rotation = GetComponent<Rotation>();
        }

        private void Update()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out var floorHit, 50f, LayerMask.GetMask("Ground")))
            {
                var pointToLook = floorHit.point;

                _rotation.LookAtOnlyInYAxis(pointToLook);
            }
        }
    }
}