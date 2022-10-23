namespace AlphDevCode.Tools
{
    public class FizzBuzzLogic
    {
        public const string FizzBuzzName = "FIZZBUZZ";
        public const string FizzName = "FIZZ";
        public const string BuzzName = "BUZZ";
        public const string DumbName = "DUMB";
        
        
        public string EvaluateNumber(int number)
        {
            if (number % 15 == 0) return FizzBuzzName;
            if (number % 3 == 0) return FizzName;
            if (number % 5 == 0) return BuzzName;
            return DumbName;
        }
    }
}