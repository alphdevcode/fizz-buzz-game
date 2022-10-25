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
            if (number % 15 == 0) return FizzBuzzLogicType.FIZZBUZZ;
            if (number % 3 == 0) return FizzBuzzLogicType.FIZZ;
            if (number % 5 == 0) return FizzBuzzLogicType.BUZZ;
            return FizzBuzzLogicType.DUMB;
        }
    }
}