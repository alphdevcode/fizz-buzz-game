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
    }
}