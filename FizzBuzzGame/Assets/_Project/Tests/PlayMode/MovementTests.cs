using System.Collections;
using AlphDevCode.Enemies;
using AlphDevCode.Player;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class MovementTests
{
    [UnityTest]
    public IEnumerator Given_ForwardDirection_Then_ObjectMoveForward()
    {
        var movement = new Movement();
        var objectTransform = new GameObject().transform;

        var startPosition = objectTransform.position;

        movement.Move(objectTransform, Vector3.forward, 100f);
        yield return null;

        var direction = (objectTransform.position - startPosition).normalized;
        
        Debug.Log($"Start: {startPosition}. End: {objectTransform.position}. Dir: {direction}");
        
        Assert.AreEqual(Vector3.forward,direction);
    }
}