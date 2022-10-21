using System.Collections;
using AlphDevCode.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{
    [UnityTest]
    public IEnumerator LookAtPoint()
    {
        var gameObject = new GameObject
        {
            transform = { position = Vector3.zero }
        };
        
        var player = gameObject.AddComponent<PlayerRotation>();
        player.LookAtOnlyInYAxis(new Vector3(1,0,0));

        yield return new WaitForSeconds(.1f);
        
        Assert.AreEqual(new Vector3(0,90,0), player.transform.eulerAngles);
    }
    
    
}