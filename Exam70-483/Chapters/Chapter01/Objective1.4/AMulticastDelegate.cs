using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483
{
	public class AMulticastDelegate
	{
		public void MethodOne()
		{
			Console.WriteLine("MethodOne");
		}

		public void MethodTwo()
		{
			Console.WriteLine("MethodTwo");
		}

		public delegate void Del();

		public void Multicast()
		{
			Del d = MethodOne;
			d += MethodTwo;
			d();

			int invocationCount = d.GetInvocationList().GetLength(0);
		}
		
		// Displays
		// MethodOne
		// MethodTwo
	}
}
