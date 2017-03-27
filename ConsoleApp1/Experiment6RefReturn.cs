using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // you can get a ref returned from a function
	class Experiment6RefReturn
	{
		public void SomeMethod()
		{
            // let's say we are looking for a number in the array
            // and want to update that with some other value
            // old style: return the index; use the index to update
            // new style: returns a ref; use it directly
			var someNumbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };
			Console.WriteLine(someNumbers[2]);
			ref var foo = ref FindElementWithValue(2, someNumbers);
            // this updates the 3rd element
			foo = 99;
			Console.WriteLine(someNumbers[2]);
		}

		private ref int FindElementWithValue(int someNumber, int[] numbers)
		{
			for (int i = 0; i < numbers.Length; i++)
				if (numbers[i] == someNumber)
					return ref numbers[i];

			throw new Exception("blah");
		}
	}
}
