using CPRFeedbackER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePRoject
{
	class Program
	{
		static void Main(string[] args)
		{
			// The code provided will print ‘Hello World’ to the console.
			// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
			var mm = new Measurment { Id = 1, Name = "Laci", Values = "594;587;577;570;561;552;541;531;520;509;497;486;474;460;448" };

			var db = new DataBaseManager();

			db.AddItem(mm);
			Console.ReadKey();

		}
	}
}
