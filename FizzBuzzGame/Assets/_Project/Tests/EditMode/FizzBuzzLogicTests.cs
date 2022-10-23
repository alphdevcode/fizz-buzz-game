using AlphDevCode.Tools;
using NUnit.Framework;
using UnityEngine;

namespace AlphDevCode.Test.EditMode
{
    public class FizzBuzzLogicTests
    {
        [TestCase(2, FizzBuzzLogic.DumbName)]
        [TestCase(13, FizzBuzzLogic.DumbName)]
        [TestCase(59, FizzBuzzLogic.DumbName)]
        [TestCase(3, FizzBuzzLogic.FizzName)]
        [TestCase(12, FizzBuzzLogic.FizzName)]
        [TestCase(27, FizzBuzzLogic.FizzName)]
        [TestCase(5, FizzBuzzLogic.BuzzName)]
        [TestCase(20, FizzBuzzLogic.BuzzName)]
        [TestCase(50, FizzBuzzLogic.BuzzName)]
        [TestCase(15, FizzBuzzLogic.FizzBuzzName)]
        [TestCase(30, FizzBuzzLogic.FizzBuzzName)]
        [TestCase(60, FizzBuzzLogic.FizzBuzzName)]
        [Test]
        public void Given_Number_Then_CheckFizzBuzzType(int number, string expectedResult)
        {
            var fizzBuzzLogic = new FizzBuzzLogic();
            Assert.AreEqual(expectedResult, fizzBuzzLogic.EvaluateNumber(number));
        }
    }
}