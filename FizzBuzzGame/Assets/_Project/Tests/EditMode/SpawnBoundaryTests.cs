using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEngine;

namespace AlphDevCode.Test.EditMode
{
    public class SpawnBoundaryTests
    {
        [TestCase(2, 3, true)]
        [TestCase(-4, 1, true)]
        [TestCase(4.99f, 4.99f, true)]
        [TestCase(6, 3, false)]
        [TestCase(5, 5, false)]
        [Test]
        public void Given_Point_Then_CheckIfInsideSafeArea(float x, float y, bool expectedResult)
        {
            var spawnBoundary = new SpawnBoundary();

            Assert.AreEqual(expectedResult, spawnBoundary.CheckIfInsideSafeArea(new Vector2(x, y)));
        }

        [Test]
        public void Given_RandomPosition_Then_PointInSpawnArea()
        {
            int timesToRepeat = 1000;
            var spawnBoundary = new SpawnBoundary();

            bool isInsideXArea = false;
            bool isInsideZArea = false;

            while (timesToRepeat > 0)
            {
                var point = spawnBoundary.GetRandomSpawnPoint();

                isInsideXArea = point.x is > -SpawnBoundary.XScreenEdge and < SpawnBoundary.XScreenEdge;
                isInsideZArea = point.y is > -SpawnBoundary.ZScreenEdge and < SpawnBoundary.ZScreenEdge;

                if(!isInsideXArea || !isInsideZArea) break;

                timesToRepeat--;
            }

            Assert.IsTrue(isInsideXArea && isInsideZArea);
        }
    }
}