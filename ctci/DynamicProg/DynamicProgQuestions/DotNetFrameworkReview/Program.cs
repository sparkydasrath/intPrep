using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DotNetFrameworkReview.Annotations;

namespace DotNetFrameworkReview
{
    public interface ITest
    {
        void Get();
    }

    public class EventTest
    {
        public event Action<string> MyEvent;

        public void RaiseEvent(string val)
        {
            Action<string> e = MyEvent;
            e?.Invoke(val);
        }
    }

    public class Inpc : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    internal class Program
    {
        private static void HandleMyE(string s)
        {
        }

        private static void Main(string[] args)
        {
            EventTest et = new EventTest();
            et.RaiseEvent("meee");

            et.MyEvent += HandleMyE;

            Console.ReadLine();
        }
    }
}