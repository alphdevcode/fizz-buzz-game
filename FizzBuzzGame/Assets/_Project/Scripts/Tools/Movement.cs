using UnityEngine;

namespace AlphDevCode.Tools
{
    public class MovementRb
    {
        public void MoveForwardRb(GameObject gameObject, Vector3 direction, float force)
        {
            var rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}