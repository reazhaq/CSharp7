using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // local function can be used like one time function within a function
    // similar to anonymous function
    // a good usage - let's say you have a method that does lots of stuff...
    // break those into "good name" local function at the bottom
    // use them in the main body of the method for better readablity
	class Experiment5LocalFunctions
	{
		public void SomeMethod()
		{
			Console.WriteLine($"Fibonnacci 5 using local function => {CalculateFibonnacci(5)}{Environment.NewLine}");
			Console.WriteLine($"Fibonnacci 3 using local function => {CalculateFibonnacci(3)}{Environment.NewLine}");

            //// some may say - "I Can Use Func For The Same Thing"....
            //// close but... Yes - but not clean
            Console.WriteLine($"Fibonnacci 5 using Func => {ICanUseFuncForTheSameThing(5)}{Environment.NewLine}");
            Console.WriteLine($"Fibonnacci 3 using Func => {ICanUseFuncForTheSameThing(3)}{Environment.NewLine}");
		}

        private int CalculateFibonnacci(int someNumber)
		{
			if (someNumber < 0) return 0;
			return LocalCalculate(someNumber).current;
            
            // note the return of Tuple and its use in the previous statement
			(int current, int previous) LocalCalculate(int i)
			{
				if (i == 0) return (1, 0);
				var (c, p) = LocalCalculate(i - 1);
				return (c + p, c);
			}
		}

        private int ICanUseFuncForTheSameThing(int someValue)
        {
            if (someValue < 0) return 0;

            //// trying to do it in one pass - doesn't work
            //// OneLineFunkyFib is called within the body - recursive call
            ///****
            //    Func<int, (int current, int previous)> OneLineFunkyFib = x =>
            //    {
            //        if (x == 0) return (1, 0);
            //        var (c, p) = OneLineFunkyFib(x - 1);
            //        return (c + p, c);
            //    };
            //****/

            // declaration needs to be on a separate line from the body
            Func<int, (int current, int previous)> FunkyFib = null;
            FunkyFib = x =>
            {
                if (x == 0) return (1, 0);
                var (c, p) = FunkyFib(x - 1);
                return (c + p, c);
            };

            // unlike local function; this call has to go to the bottom
            return FunkyFib(someValue).current;
        }
    }
}
