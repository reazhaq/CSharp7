using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // you can get a ref returned from a function
    // we had been passing parameters as REF from day one - this is same for return
	class Experiment6RefReturn
	{
		public void SomeMethod()
		{
            // let's say we are looking for a number in the array
            // and want to update that with some other value
			var someNumbers = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };

            // old style: return the index; use the index to update
            Console.WriteLine($"someNumbers[3] = {someNumbers[3]} before");
            var elementIndex = FindElementWithValueAndReturnIndex(3, someNumbers);
            someNumbers[elementIndex] = 33;
            Console.WriteLine($"someNumbers[3] = {someNumbers[3]} after");

            // new style: returns a ref; use it directly
            Console.WriteLine($"someNumbers[2] = {someNumbers[2]} before");
            ref var foo = ref FindElementWithValue(2, someNumbers);
			foo = 22;
            Console.WriteLine($"someNumbers[2] = {someNumbers[2]} after");
        }

        private int FindElementWithValueAndReturnIndex(int someNumber, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] == someNumber)
                    return i;

            throw new Exception("blah");
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
