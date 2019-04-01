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
        private static void Main(string[] args) => Console.ReadLine();
    }
}

public delegate void Print(int a);