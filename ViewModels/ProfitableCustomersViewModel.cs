using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ais.Models;
using ais.Tools.Managers;

namespace ais.ViewModels
{
    class ProfitableCustomersViewModel
    {
        public ProfitableCustomersViewModel(bool asc)
        {
            CustomersList = new ObservableCollection<Customer>(StationManager.DataStorage.MostProfitableCustomers(asc));
        }
        public ObservableCollection<Customer> CustomersList { get; }
    } 
}
