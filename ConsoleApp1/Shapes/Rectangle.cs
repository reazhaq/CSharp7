using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Shapes
{
	class Rectangle : Shape
	{
		public Rectangle(string name, int corners) : base(name, corners)
		{
		}

		public int Height { get; set; }
		public int Width { get; set; }
	}
}
