using System.Collections;
using System.Collections.Generic;
using AlphDevCode.Player;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{
    [Test]
    public void Given_LookAtPointRight_Then_LookRight()
    {
        var gameObject = new GameObject
        {
            transform = { position = Vector3.zero }
        };
        
        var player = gameObject.AddComponent<PlayerRotation>();
        player.LookAtOnlyInYAxis(new Vector3(1,0,0));
        
        Assert.AreEqual(new Vector3(0,90,0), player.transform.eulerAngles);
    }
    
    [Test]
    public void Given_LookAtPointDown_Then_LookDown()
    {
        var gameObject = new GameObject
        {
            transform = { position = Vector3.zero }
        };
        
        var player = gameObject.AddComponent<PlayerRotation>();
        player.LookAtOnlyInYAxis(new Vector3(0,0,-1));
        
        Assert.AreEqual(new Vector3(0,180,0), player.transform.eulerAngles);
    }
    
}
