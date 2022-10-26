using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

namespace AlphDevCode.Tools
{
    public class FizzBuzzLogic
    {
        private const int LowerNumber = 1;
        private const int HigherNumber = 61;

        public int GetRandomNumber()
        {
            return Random.Range(LowerNumber, HigherNumber);
        }
        
        public FizzBuzzLogicType EvaluateNumber(int number)
        {
            if (number % 15 == 0) return FizzBuzzLogicType.FizzBuzz;
            if (number % 3 == 0) return FizzBuzzLogicType.Fizz;
            if (number % 5 == 0) return FizzBuzzLogicType.Buzz;
            return FizzBuzzLogicType.Dumb;
        }
    }
}