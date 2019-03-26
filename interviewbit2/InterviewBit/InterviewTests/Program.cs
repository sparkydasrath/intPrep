using System;

namespace InterviewTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Centerbridge cb = new Centerbridge(null, null);
            cb.GeneratePhoneNumbers();

            Console.ReadLine();
        }
    }
}