using System.Collections;
using AlphDevCode.Enemies;
using AlphDevCode.Player;
using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class MovementRbTests
{
    [UnityTest]
    public IEnumerator Given_ForwardDirection_Then_ObjectMoveForward()
    {
        var movement = new Movement();
        var gameObject = new GameObject();
        movement.Move(gameObject, Vector3.forward, 100f);

        var startPosition = gameObject.transform.position;

        yield return new WaitForSeconds(.1f);

        var direction = (gameObject.transform.position - startPosition).normalized;
        
        Assert.AreEqual(Vector3.forward,direction);
    }
}