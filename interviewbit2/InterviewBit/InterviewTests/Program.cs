using System;

namespace InterviewTests
{
    public class A
    {
        // public delegate void Print(int a);

        public event EventHandler<int> DoActionEvent;

        public static int i = 1;
        public int j = 1;

        public void DoingStuffToRaiseEvent() => OnDoActionEvent(100);

        protected virtual void OnDoActionEvent(int e)
        {
            Console.WriteLine("raising event");
            DoActionEvent?.Invoke(this, e);
        }
    }

    internal class Program
    {
        private static void Main(string[] args) =>
            /* CENTERBRIDGE

char[,] data =
{
{ '1','2','3'},
{ '4','5','6'},
{ '7','8','9'},
{ '*','0','#'},
};

char[] exclusionList = { '*', '#' };
char[] nonStartingList = { '0', '1' };

Centerbridge cbe = new Centerbridge(data, exclusionList, nonStartingList);
Console.WriteLine($"Rook count 7-digit = {cbe.GetNumberCount(ChessPiece.Rook, NumberLength.Seven)}");
Console.WriteLine($"Rook count 9-digit = {cbe.GetNumberCount(ChessPiece.Rook, NumberLength.Nine)}");

Console.WriteLine($"Queen count 7-digit = {cbe.GetNumberCount(ChessPiece.Queen, NumberLength.Seven)}");
Console.WriteLine($"Queen count 9-digit = {cbe.GetNumberCount(ChessPiece.Queen, NumberLength.Nine)}");
Console.ReadLine();

*/

            Console.ReadLine();
    }
}

public delegate void Print(int a);