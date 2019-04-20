using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRFeedbackER
{
	
	public class Measurement
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string Comment { get; set; }
		public string Values { get; set; }
        public DateTime Date { get; set; }
	}
}
