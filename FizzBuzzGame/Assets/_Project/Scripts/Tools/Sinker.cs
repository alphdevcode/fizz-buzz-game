using System;
using System.Collections;
using UnityEngine;

namespace AlphDevCode.Tools
{
    public class Sinker
    {
        private readonly Transform _transform;

        public Sinker(Transform transform)
        {
            _transform = transform;
        }

        public IEnumerator SinkDown(float sinkSpeed, float distanceToSink, Action callback = null)
        {
            var initialPosition = _transform.position.y;
            var movement = new Movement();
            
            while (Mathf.Abs(_transform.position.y - initialPosition) < distanceToSink)
            {
                movement.Move(_transform, Vector3.down, sinkSpeed);
                yield return null;
            }
                
            callback?.Invoke();
        }
    }
}