using System.IO;

namespace Exam70_483
{
	public class CovarianceWithDelegates
	{
		public delegate TextWriter CovarianceDel();

		public StreamWriter MethodStream()
		{
			return null;
		}

		public StringWriter MethodString()
		{
			return null;
		}

		//Because both StreamWriter and StringWriter inherit from TextWriter, you can use the CovarianceDel with both methods.
		public void Do()
		{
			CovarianceDel del;
			del = MethodStream;
			del = MethodString;
		}
	}
}
