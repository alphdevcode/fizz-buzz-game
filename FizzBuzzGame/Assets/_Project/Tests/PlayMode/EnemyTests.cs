using System.Collections;
using _Project.Scripts.Enemies;
using AlphDevCode.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTests
{
    [UnityTest]
    public IEnumerator MoveToPoint()
    {
        var gameObject = new GameObject
        {
            transform = { position = new Vector3(10,1,10) }
        };
        
        var enemy = gameObject.AddComponent<EnemyMovement>();

        // initial
        yield return new WaitForSeconds(1f);
        
       
        // Assert.AreEqual(new Vector3(0,90,0), player.transform.eulerAngles);
    }
    
    
}