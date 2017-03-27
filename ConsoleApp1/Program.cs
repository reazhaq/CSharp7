using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			new Experiment1Tuple().SomeMethod();

			new Experiment2Deconstructor().SomeMethod();

			new Experiment3OutVariable().SomeMethod();

			new Experiment4PatternMatching().SomeMethod();

			new Experiment5LocalFunctions().SomeMethod();

			new Experiment6RefReturn().SomeMethod();

            new Experiment7ExpressionBody().SomeMethod();

            // use ValueTask instead of Task.FromResult....
		}
	}
}
