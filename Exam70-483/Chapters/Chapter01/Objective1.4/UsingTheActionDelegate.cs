using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483
{
	public class UsingTheActionDelegate
	{
		Action<int, int> calc = (x, y) =>
		{
			Console.WriteLine(x + y);
		};

		public void Do()
		{
			calc(3, 4);
		}
	}
}
