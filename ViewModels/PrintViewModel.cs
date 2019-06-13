using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ais.Tools;
using ais.Tools.Managers;

namespace ais.ViewModels
{
    class PrintViewModel
    {
        public string NameTable { get; }
        public ObservableCollection<object> SelectedTable { get; }

        public PrintViewModel(string name)
        {
            NameTable = name;

            switch (NameTable)
            {
                case "Customer":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.CustomersList);
                    break;
                case "Cust_Tel":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.CustTelsList);
                    break;
                case "Cornices":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.CornicesList);
                    break;
                case "Workshop":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.WorkshopsList);
                    break;
                case "Order":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.OrdersList);
                    break;
                case "Contractor":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.ContractorsList);
                    break;
                case "Contractor_Tel":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.ContractorTelList);
                    break;
                case "Goods":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.GoodsList);
                    break;
                case "Contractor_Goods":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.ContractorGoodsList);
                    break;
                case "Order_Goods":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.OrderGoodsList);
                    break;
                case "Contract":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.ContractsList);
                    break;
                case "Contract_Goods":
                    SelectedTable  = new ObservableCollection<object>(StationManager.DataStorage.ContractGoodsList);
                    break;
             }
        }
    }
}
