using System;

namespace InterviewTests.centerbridge
{
    public static class ValidateParameters
    {
        public static void Input(char[,] input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "Input is null - please enter a valid matrix");
            if (input.GetLength(0) == 0 || input.GetLength(1) == 0) throw new ArgumentException("Input is not properly formed - one of the dimensions is zero", nameof(input));
        }

        public static void LengthOfDesiredPhoneNumber(char[,] input, NumberLength numberLength)
        {
            if (input.GetLength(0) * input.GetLength(1) < (int)numberLength)
                throw new ArgumentException($"Input size too small to generate numbers of length {numberLength}", nameof(numberLength));
        }
    }
}