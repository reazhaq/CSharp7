﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Shapes
{
	class Triangle : Shape
	{
		public Triangle(string name, int corners) : base(name, corners)
		{
		}

		public int Base { get; set; }
		public int Height { get; set; }
	}
}
