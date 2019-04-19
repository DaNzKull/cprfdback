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
		bool AddItem(Measurement mes);
		bool DeleteItem(Measurement mes);
		ObservableCollection<Measurement> GetAllItems();
		bool UpdateItem(Measurement mes);
		List<Measurement> GetItemById(int id);
	}
}
