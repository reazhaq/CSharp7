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
        private int Age { get; set; }

		public SomeClass2(string first, string last, int age)
		{
			FirstName = first;
			LastName = last;
            Age = age;
		}

		public void Deconstruct(out string first, out string last, out int age)
		{
			first = FirstName;
			last = LastName;
            age = Age;
		}
	}

	class Experiment2Deconstructor
	{
		public void SomeMethod()
		{
			var foo = new SomeClass2("jon", "doe", 24);

            // old style use; that was taking multiple lines
			var fn = foo.FirstName;
			var ln = foo.LastName;
			Console.WriteLine($"foo.FirstName = {fn}, foo.LastName = {ln}{Environment.NewLine}");

            // new style use; one line
            // it can also return private ones; that have no property
			var (fn2, ln2, ag) = foo;
			Console.WriteLine($"{(fn2, ln2, ag)} comes from foo Deconstruct with values:" +
                $" {fn2}, {ln2}, and {ag}{Environment.NewLine}");
		}
	}
}
