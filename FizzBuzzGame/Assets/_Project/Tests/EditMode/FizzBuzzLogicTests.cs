using AlphDevCode.Tools;
using NUnit.Framework;

namespace Tests
{
    public class FizzBuzzLogicTests
    {
        [Test]
        [TestCase(2, FizzBuzzLogicType.Dumb)]
        [TestCase(13, FizzBuzzLogicType.Dumb)]
        [TestCase(59, FizzBuzzLogicType.Dumb)]
        [TestCase(3, FizzBuzzLogicType.Fizz)]
        [TestCase(12, FizzBuzzLogicType.Fizz)]
        [TestCase(27, FizzBuzzLogicType.Fizz)]
        [TestCase(5, FizzBuzzLogicType.Buzz)]
        [TestCase(20, FizzBuzzLogicType.Buzz)]
        [TestCase(50, FizzBuzzLogicType.Buzz)]
        [TestCase(15, FizzBuzzLogicType.FizzBuzz)]
        [TestCase(30, FizzBuzzLogicType.FizzBuzz)]
        [TestCase(60, FizzBuzzLogicType.FizzBuzz)]
        public void Given_Number_Then_CheckFizzBuzzLogicType(int number, FizzBuzzLogicType expectedType)
        {
            var fizzBuzzLogic = new FizzBuzzLogic();
            Assert.AreEqual(expectedType, fizzBuzzLogic.EvaluateNumber(number));
        }
    }
}