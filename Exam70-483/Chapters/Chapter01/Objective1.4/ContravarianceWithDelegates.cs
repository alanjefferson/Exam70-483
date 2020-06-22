using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483
{
	public class ContravarianceWithDelegates
	{
		void DoSomething(TextWriter tw)
		{
			//Here
		}

		public delegate void ContravarianceDel(StreamWriter tw);

		public void Do()
		{
			ContravarianceDel del = DoSomething;
		}
	}
}
