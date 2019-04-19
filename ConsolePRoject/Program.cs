using CPRFeedbackER;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePRoject
{
	class Program
	{
		static void Main(string[] args)
		{

			//Itt egy példa az adatbázis  használatára.
			var mm = new Measurement { Id = 1, Name = "Laci", Values = "594;587;577;570;561;552;541;531;520;509;497;486;474;460;448" };

			var db = new DataBaseManager();

			db.AddItem(mm);
			ICollection< Measurement> col = db.GetAllItems();
			foreach (var item in col)
			{
				Console.WriteLine(item);
			}
			Console.ReadKey();

		}
	}
}
