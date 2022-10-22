using System.Collections;
using AlphDevCode.Enemies;
using AlphDevCode.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

public class EnemyTests
{
    [UnityTest]
    public IEnumerator MoveToPoint()
    {
        var enemyAgent = new GameObject
        {
            transform = { position = new Vector3(10,0,10) }
        }
            .AddComponent<NavMeshAgentMovement>();
        
        enemyAgent.GetComponent<NavMeshAgent>().speed = 10;
        var pointToMove = Vector3.zero;

        var previousDistance = Vector3.Distance(enemyAgent.transform.position, pointToMove);
        enemyAgent.MoveTo(pointToMove);
        
        
        
        
        yield return new WaitForSeconds(.1f);
        
        // Assert.Less(Vector3.Distance(enemyAgent.transform.position, pointToMove), previousDistance);
        
       
        // Assert.AreEqual(new Vector3(0,90,0), player.transform.eulerAngles);
    }
    
    
}