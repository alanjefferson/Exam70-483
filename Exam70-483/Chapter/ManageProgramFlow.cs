using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Exam70_483
{
	public class ManageProgramFlow
	{
		#region Objective 1.1: Implement multithreading and asynchronous processing

		//LISTING 1-30
		public void UsingAConcurrentBag()
		{
			ConcurrentBag<int> bag = new ConcurrentBag<int>();

			bag.Add(42);
			bag.Add(21);
			int result;

			if (bag.TryTake(out result))
				Console.WriteLine(result);

			if (bag.TryPeek(out result))
				Console.WriteLine("There is a next item: {0}", result);
		}

		//LISTING 1-31
		public void EnumeratingAConcurrentBag()
		{
			ConcurrentBag<int> bag = new ConcurrentBag<int>();
			Task.Run(() =>
			{
				bag.Add(42);
				Thread.Sleep(1000);
				bag.Add(21);
			});
			Task.Run(() =>
			{
				foreach (int i in bag)
					Console.WriteLine(i);
			}).Wait();

			// Displays
			// 42
		}

		//LISTING 1-32
		public void UsingAConcurrentStack()
		{
			ConcurrentStack<int> stack = new ConcurrentStack<int>();
			stack.Push(42);

			int result;
			if (stack.TryPop(out result))
				Console.WriteLine("Popped: {0}", result);

			stack.PushRange(new int[] { 1, 2, 3 });

			int[] values = new int[2];
			stack.TryPopRange(values); //LIFO

			foreach (int i in values)
				Console.WriteLine(i);

			// Popped: 42
			// 3
			// 2
		}

		//LISTING 1-33
		public void UsingAConcurrentQueue()
		{
			ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
			queue.Enqueue(42);

			int result;
			if (queue.TryDequeue(out result)) //FIFO
				Console.WriteLine("Dequeued: {0}", result);

			// Dequeued: 42
		}

		//LISTING 1-34
		public void UsingAConcurrentDictionary()
		{
			var dict = new ConcurrentDictionary<string, int>();

			if (dict.TryAdd("k1", 42))
			{
				Console.WriteLine("Added");
			}

			if (dict.TryUpdate("k1", 21, 42))
			{
				Console.WriteLine("42 updated to 21");
			}

			dict["k1"] = 42; // Overwrite unconditionally
			int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
			int r2 = dict.GetOrAdd("k2", 3);
		}

		#endregion

		#region Objective 1.2: Manage multithreading

		//LISTING 1-35 Accessing shared data in a multithreaded application
		public void AccessingSharedDataMultiThread()
		{
			int n = 0;

			var up = Task.Run(() =>
			{
				for (int i = 0; i < 1000000; i++)
					n++;
			});

			for (int i = 0; i < 1000000; i++)
				n--;

			up.Wait();
			Console.WriteLine(n);
		}

		//LISTING 1-36 Using the lock keyword
		public void UsingTheLockKeyword()
		{
			int n = 0;

			object _lock = new object();

			var up = Task.Run(() =>
			{
				for (int i = 0; i < 1000000; i++)
					lock (_lock)
						n++;
			});

			for (int i = 0; i < 1000000; i++)
				lock (_lock)
					n--;

			up.Wait();
			Console.WriteLine(n);
		}

		//LISTING 1-37 Creating a deadlock
		public void CreatingADeadlock()
		{
			object lockA = new object();
			object lockB = new object();
			var up = Task.Run(() =>
			{
				lock (lockA)
				{
					Thread.Sleep(1000);
					lock (lockB)
					{
						Console.WriteLine("Locked A and B");
					}
				}
			});
			lock (lockB)
			{
				lock (lockA)
				{
					Console.WriteLine("Locked B and A");
				}
			}
			up.Wait();
		}

		//LISTING 1-38 Generated code from a lock statement
		public void GeneratedCodeFromALockStatement()
		{
			object gate = new object();
			bool __lockTaken = false;
			try
			{
				Monitor.Enter(gate, ref __lockTaken);
			}
			finally
			{
				if (__lockTaken)
					Monitor.Exit(gate);
			}
		}

		//LISTING 1-40 Using the Interlocked class
		public void UsingTheInterlockedClass()
		{
			int n = 0;

			var up = Task.Run(() =>
			{
				for (int i = 0; i < 1000000; i++)
					Interlocked.Increment(ref n);
			});

			for (int i = 0; i < 1000000; i++)
				Interlocked.Decrement(ref n);

			up.Wait();
			Console.WriteLine(n);
		}

		//LISTING 1-41 Compare and exchange as a nonatomic operation
		public void CompareAndExchangeAsANonatomicOperation()
		{
			int value = 1;

			Task t1 = Task.Run(() =>
			{
				if (value == 1)
				{
					// Removing the following line will change the output
					Thread.Sleep(1000);
					value = 2;
				}
			});

			Task t2 = Task.Run(() =>
			{
				value = 3;
			});

			Task.WaitAll(t1, t2);
			Console.WriteLine(value); // Displays 2
		}

		//LISTING 1-42 Using a CancellationToken
		public void UsingACancellationToken()
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			CancellationToken token = cancellationTokenSource.Token;

			Task task = Task.Run(() =>
			{
				while (!token.IsCancellationRequested)
				{
					Console.Write("*");
					Thread.Sleep(1000);
				}
			}, token);

			Console.WriteLine("Press enter to stop the task");
			Console.ReadLine();
			cancellationTokenSource.Cancel();

			Console.WriteLine("Press enter to end the application");
			Console.ReadLine();
		}

		//LISTING 1-43 Throwing OperationCanceledException
		public void ThrowingOperationCanceledException()
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			CancellationToken token = cancellationTokenSource.Token;

			Task task = Task.Run(() =>
			{
				while (!token.IsCancellationRequested)
				{
					Console.Write("*");
					Thread.Sleep(1000);
				}
				token.ThrowIfCancellationRequested();
			}, token);
			
			try
			{
				Console.WriteLine("Press enter to stop the task");
				Console.ReadLine();
				cancellationTokenSource.Cancel();
				task.Wait();
			}
			catch (AggregateException e)
			{
				Console.WriteLine(e.InnerExceptions[0].Message);
			}

			Console.WriteLine("Press enter to end the application");
			Console.ReadLine();
		}
		
		//LISTING 1-44 Adding a continuation for canceled tasks
		public void AddingAContinuationForCanceledTasks()
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			CancellationToken token = cancellationTokenSource.Token;

			Task task = Task.Run(() =>
			{
				while (!token.IsCancellationRequested)
				{
					Console.Write("*");
					Thread.Sleep(1000);
				}
			}, token).ContinueWith((t) =>
			{
				t.Exception.Handle((e) => true);
				Console.WriteLine("You have canceled the task");
			}, TaskContinuationOptions.OnlyOnCanceled);

			try
			{
				Console.WriteLine("Press enter to stop the task");
				Console.ReadLine();
				cancellationTokenSource.Cancel();
				task.Wait();
			}
			catch (AggregateException e)
			{
				Console.WriteLine(e.InnerExceptions[0].Message);
			}

			Console.WriteLine("Press enter to end the application");
			Console.ReadLine();
		}

		//LISTING 1-45 Setting a timeout on a task
		public void SettingATimeoutOnATask()
		{
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			CancellationToken token = cancellationTokenSource.Token;

			Task longRunning = Task.Run(() =>
			{
				Thread.Sleep(10000);
			});

			int index = Task.WaitAny(new[] { longRunning }, 1000);

			if (index == -1)
				Console.WriteLine("Task timed out");

			Console.ReadLine();
		}

		#endregion

		#region Objective 1.3: Implement program flow
		#endregion

		#region Objective 1.4: Create and implement events and callbacks
		#endregion

		#region Objective 1.5. Implement exception handling
		#endregion
	}
}
