using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // local function can be used like one time function within a function
	class Experiment5LocalFunctions
	{
		public void SomeMethod()
		{
			Console.WriteLine($"Fibonnacci 5 => {CalculateFibonnacci(5)}{Environment.NewLine}");
			Console.WriteLine($"Fibonnacci 3 => {CalculateFibonnacci(3)}{Environment.NewLine}");

            //// close but...
            ICanUseFuncForTheSameThing(5);
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

        private void ICanUseFuncForTheSameThing(int someValue)
        {
            int something = 10;
            //// this doesn't work
            //// have to separate the def from body
            /*****
                Func<int, int> someFunc = x =>
                {
                    if (x == 0)
                        return 0;
                    return x + someFunc(x - 1);
                };
            ******/

            // this works - notice the separation of def and body
            Func<int, int> someFunc = null;
            someFunc = x =>
            {
                if (x <= 0)
                    return 0;
                return x + someFunc(x - 1);
            };

            something = someFunc(someValue);
        }
    }
}
