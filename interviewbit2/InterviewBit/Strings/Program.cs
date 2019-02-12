using System;

namespace Strings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AddCommas ac = new AddCommas();
            string rer = ac.AddCommasInCorrectPlaces("888888");
            Console.WriteLine(rer);

            Console.ReadLine();
        }
    }
}