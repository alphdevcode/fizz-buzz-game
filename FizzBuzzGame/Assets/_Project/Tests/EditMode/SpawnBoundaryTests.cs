using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class SpawnBoundaryTests
    {
        [Test]
        public void Given_PointsInside_Then_PointsInSafeArea([NUnit.Framework.Range(-4,4)] float x, [NUnit.Framework.Range(-3,3)] float y)
        {
            var spawnBoundary = new SpawnBoundary();

            Assert.AreEqual(true, spawnBoundary.CheckIfInsideSafeArea(new Vector2(x, y)));
        }
        
        [Test]
        public void Given_PointsAboveOrBelow_Then_PointsOutsideSafeArea([NUnit.Framework.Range(-4,4)] float x, [Values(-8,7)] float y)
        {
            var spawnBoundary = new SpawnBoundary();

            Assert.AreEqual(false, spawnBoundary.CheckIfInsideSafeArea(new Vector2(x, y)));
        }
        
        [Test]
        public void Given_PointsOnLeftOrRight_Then_PointsOutsideSafeArea([Values(-6,6)] float x, [NUnit.Framework.Range(-4,4)] float y)
        {
            var spawnBoundary = new SpawnBoundary();

            Assert.AreEqual(false, spawnBoundary.CheckIfInsideSafeArea(new Vector2(x, y)));
        }

        [Test, Repeat(100)]
        public void Given_RandomPosition_Then_PointInSpawnArea()
        {
            var spawnBoundary = new SpawnBoundary();
            var point = spawnBoundary.GetRandomSpawnPoint();

            bool isInsideXArea = point.x is > -SpawnBoundary.XScreenEdge and < SpawnBoundary.XScreenEdge;
            bool isInsideZArea = point.y is > -SpawnBoundary.ZScreenEdge and < SpawnBoundary.ZScreenEdge;
            
            Assert.IsTrue(isInsideXArea && isInsideZArea);
        }
    }
}