using System;
using System.Collections;
using UnityEngine;

namespace AlphDevCode.Enemies
{
    public class Sinker
    {
        private Transform _transform;

        public Sinker(Transform transform)
        {
            _transform = transform;
        }

        public IEnumerator SinkDown(float sinkSpeed, float distanceToSink)
        {
            _transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
            
            if (Math.Abs(_transform.position.y - (-distanceToSink)) < float.Epsilon)
                yield return null;
        }
    }
}