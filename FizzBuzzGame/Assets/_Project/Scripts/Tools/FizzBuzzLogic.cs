using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

namespace AlphDevCode.Tools
{
    public class FizzBuzzLogic
    {
        public const string FizzBuzzName = "FIZZBUZZ";
        public const string FizzName = "FIZZ";
        public const string BuzzName = "BUZZ";
        public const string DumbName = "DUMB";

        private const int LowerNumber = 1;
        private const int HigherNumber = 61;

        public int GetRandomNumber()
        {
            return Random.Range(LowerNumber, HigherNumber);
        }
        
        public string EvaluateNumber(int number)
        {
            if (number % 15 == 0) return FizzBuzzName;
            if (number % 3 == 0) return FizzName;
            if (number % 5 == 0) return BuzzName;
            return DumbName;
        }
    }
}