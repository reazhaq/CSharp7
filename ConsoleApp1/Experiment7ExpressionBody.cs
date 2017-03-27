using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // c# 6 introduced arrow function; but it was limited to methods, properties,...
    // now it can be used for constructor, finalizer etc.
    // this was a community contribution
    class Experiment7ExpressionBody
    {
        public void SomeMethod()
        {
            // showing Dispose call which is a expression body
            using (var someClass1 = new SomeClass("bob"))
            {
                Console.WriteLine($"my name is {someClass1.MyName}{Environment.NewLine}");
            }

            // showing null arg exception from expression body
            try
            {
                var someClass3 = new SomeClass(null);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message+Environment.NewLine);
            }

            // showing finalizer using expression body
            var someClass2 = new SomeClass("john");
            Console.WriteLine($"my name is {someClass2.MyName}{Environment.NewLine}");
        }
    }

    class SomeClass : IDisposable
    {
        public SomeClass(string someName) => MyName = someName;
        ~SomeClass() => InternalDispose(false);

        private string _myName;
        public string MyName
        {
            get => _myName;
            private set => _myName = value ?? throw new ArgumentNullException("MyName", "name can't be null");
        }

        public void Dispose() => InternalDispose(true);

        protected virtual void InternalDispose(bool disposing)
        {
            if (disposing)
            {
                Console.WriteLine($"IDispose.Dispose called{Environment.NewLine}");
                GC.SuppressFinalize(this);
            }
            else
            {
                Console.WriteLine($"Dispose called from finalizer{Environment.NewLine}");
                Thread.Sleep(5000);
            }
        }
    }
}
