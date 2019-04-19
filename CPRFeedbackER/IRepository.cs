using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CPRFeedbackER {

    public interface IRepository {

        bool AddItem(Measurment mes);

        bool DeleteItem(Measurment mes);

        ObservableCollection<Measurment> GetAllItems();

        bool UpdateItem(Measurment mes);

        List<Measurment> GetItemById(int id);
    }
}