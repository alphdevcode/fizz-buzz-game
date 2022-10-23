using UnityEngine;

namespace AlphDevCode.Tools
{
    public class Movement
    {
        public void Move(Transform transform, Vector3 direction, float speed)
        { 
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}