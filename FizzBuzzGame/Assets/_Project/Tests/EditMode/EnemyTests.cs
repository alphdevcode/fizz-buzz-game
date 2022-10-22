using System.Collections;
using System.Collections.Generic;
using AlphDevCode.Enemies;
using AlphDevCode.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTests
{
    [Test]
    public void Given_TakeDamage_Then_Die()
    {
        var gameObject = new GameObject
        {
            transform = { position = Vector3.zero }
        };
        gameObject.AddComponent<BoxCollider>();
        var enemy = gameObject.AddComponent<EnemyHealth>();
        
        enemy.TakeDamage();

        Assert.IsFalse(enemy.GetComponent<BoxCollider>().enabled);
    }
}