using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // deconstructor can be used to return internal information using out variables
    // use it with a Tuple; you have simple reab-able code
	class SomeClass2
	{
		public string FirstName { get; private set; }
		public string LastName { get; private set; }

		public SomeClass2(string first, string last)
		{
			FirstName = first;
			LastName = last;
		}

		public void Deconstruct(out string first, out string last)
		{
			first = FirstName;
			last = LastName;
		}
	}

	class Experiment2Deconstructor
	{
		public void SomeMethod()
		{
			var foo = new SomeClass2("jon", "doe");

            // old style use; that was taking multiple lines
			var fn = foo.FirstName;
			var ln = foo.LastName;
			Console.WriteLine($"foo.FirstName = {fn}, foo.LastName = {ln}{Environment.NewLine}");

            // new style use; one line
			var (fn2, ln2) = foo;
			Console.WriteLine($"{(fn2, ln2)} comes from foo Deconstruct with values{Environment.NewLine}" +
                $"{fn2} and {ln2}{Environment.NewLine}");
		}
	}
}
