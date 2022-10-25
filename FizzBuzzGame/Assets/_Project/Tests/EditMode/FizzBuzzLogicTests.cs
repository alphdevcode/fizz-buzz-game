using AlphDevCode.Tools;
using NUnit.Framework;

namespace Tests
{
    public class FizzBuzzLogicTests
    {
        [Test]
        [TestCase(2, FizzBuzzLogicType.DUMB)]
        [TestCase(13, FizzBuzzLogicType.DUMB)]
        [TestCase(59, FizzBuzzLogicType.DUMB)]
        [TestCase(3, FizzBuzzLogicType.FIZZ)]
        [TestCase(12, FizzBuzzLogicType.FIZZ)]
        [TestCase(27, FizzBuzzLogicType.FIZZ)]
        [TestCase(5, FizzBuzzLogicType.BUZZ)]
        [TestCase(20, FizzBuzzLogicType.BUZZ)]
        [TestCase(50, FizzBuzzLogicType.BUZZ)]
        [TestCase(15, FizzBuzzLogicType.FIZZBUZZ)]
        [TestCase(30, FizzBuzzLogicType.FIZZBUZZ)]
        [TestCase(60, FizzBuzzLogicType.FIZZBUZZ)]
        public void Given_Number_Then_CheckFizzBuzzLogicType(int number, FizzBuzzLogicType expectedType)
        {
            var fizzBuzzLogic = new FizzBuzzLogic();
            Assert.AreEqual(expectedType, fizzBuzzLogic.EvaluateNumber(number));
        }
    }
}