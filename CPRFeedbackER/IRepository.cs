using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRFeedbackER
{
	public interface IRepository
	{
		bool AddItem(Measurment mes);
		bool DeleteItem(Measurment mes);
		ObservableCollection<Measurment> GetAllItems();
		bool UpdateItem(Measurment mes);
	}
}
