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
			//ManageProgramFlow chapter01 = new ManageProgramFlow();

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
			//chapter01.SettingATimeoutOnATask();
			#endregion

			#region Objective 1.3: Implement program flow
			#endregion

			#region Objective 1.4: Create and implement events and callbacks

			UsingADelegate listing75 = new UsingADelegate();
			listing75.UseDelegate();

			AMulticastDelegate listing76 = new AMulticastDelegate();
			listing76.Multicast();

			CovarianceWithDelegates listing77 = new CovarianceWithDelegates();
			listing77.Do();

			ContravarianceWithDelegates listing78 = new ContravarianceWithDelegates();
			listing78.Do();

			UsingTheActionDelegate listing80 = new UsingTheActionDelegate();
			listing80.Do();

			#endregion

			#region Objective 1.5. Implement exception handling
			#endregion

			CreateAndUseTypes chapter02 = new CreateAndUseTypes();

			#region Objective 2.1: 
			//chapter02.checkEnumByte();
			chapter02.listing21();
			#endregion
		}
	}
}
