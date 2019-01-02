using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483
{
	class Program
	{
		static void Main(string[] args)
		{
			ManageProgramFlow chapter01 = new ManageProgramFlow();

			#region Objective 1.1: Implement multithreading and asynchronous processing
			//chapter01.UsingAConcurrentBag();
			//chapter01.EnumeratingAConcurrentBag();
			//chapter01.UsingAConcurrentStack();
			//chapter01.UsingAConcurrentQueue();
			//chapter01.UsingAConcurrentDictionary();
			#endregion

			#region Objective 1.2: Manage multithreading
			//chapter01.AccessingSharedDataMultiThread();
			//chapter01.UsingTheLockKeyword();
			//chapter01.CreatingADeadlock();
			//chapter01.GeneratedCodeFromALockStatement();
			//chapter01.UsingTheInterlockedClass();
			//chapter01.CompareAndExchangeAsANonatomicOperation();
			//chapter01.UsingACancellationToken();
			//chapter01.ThrowingOperationCanceledException();
			//chapter01.AddingAContinuationForCanceledTasks();
			chapter01.SettingATimeoutOnATask();
			#endregion

			#region Objective 1.3: Implement program flow
			#endregion

			#region Objective 1.4: Create and implement events and callbacks
			#endregion

			#region Objective 1.5. Implement exception handling
			#endregion
		}
	}
}
