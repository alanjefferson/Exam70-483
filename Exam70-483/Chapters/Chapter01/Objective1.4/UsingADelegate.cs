using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483
{
	public class UsingADelegate
	{
		public delegate int Calculate(int x, int y);

		public int Add(int x, int y)
		{
			return x + y;
		}

		public int Multiply(int x, int y)
		{
			return x * y;
		}

		public void UseDelegate()
		{
			Calculate calc = Add;
			Console.WriteLine(calc(3, 4)); // Displays 7

			calc = Multiply;
			Console.WriteLine(calc(3, 4)); // Displays 12
		}
	}
}
