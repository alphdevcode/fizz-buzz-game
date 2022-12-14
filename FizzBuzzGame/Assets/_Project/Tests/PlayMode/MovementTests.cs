using System.Collections;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovementTests
    {
        [UnityTest]
        public IEnumerator Given_ForwardDirection_Then_ObjectMoveForward()
        {
            var movement = new Movement();
            var objectTransform = new GameObject().transform;

            var initialPosition = objectTransform.position;

            movement.Move(objectTransform, Vector3.forward, 100f);
            yield return null;

            var direction = (objectTransform.position - initialPosition).normalized;

            // Debug.Log($"Start: {initialPosition}. End: {objectTransform.position}. Dir: {direction}");

            Assert.AreEqual(Vector3.forward, direction);
        }
    }
}