using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483
{
	public class CreateAndUseTypes
	{
		public enum Gender { Male, Female };
		public enum ByteDays : byte { Sat = 1, Sun, Mon, Tue, Wed, Thu, Fri };

		[Flags]
		enum Days
		{
			None = 0x0,
			Sunday = 0x1,
			Monday = 0x2,
			Tuesday = 0x4,
			Wednesday = 0x8,
			Thursday = 0x10,
			Friday = 0x20,
			Saturday = 0x40
		}

		public struct Point
		{
			public int x, y;
			public Point(int p1, int p2)
			{
				x = p1;
				y = p2;
			}
		}

		public void checkEnumByte()
		{
			ByteDays day = ByteDays.Sat;
			
			if ((byte)day == 1)
			{
				Console.Write("Is Saturday!");
			}
		}

		public void listing21()
		{
			Days readingDays = Days.Monday | Days.Saturday;

			Days currDay = Days.Monday;
			Console.WriteLine(readingDays.Equals(currDay));
		}

	}
}
