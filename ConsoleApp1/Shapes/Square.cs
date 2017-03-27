using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Shapes
{
	class Square : Shape
	{
		public Square(string name, int corners) : base(name, corners)
		{
		}

		public int Side { get; set; }
	}
}
