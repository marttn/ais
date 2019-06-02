using ais.Models;
using ais.Tools.DataStorage;
using System;

namespace ais.Tools.Managers
{
    internal static class StationManager
    {
        private static IDataStorage _dataStorage;
        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        internal static Users CurrentUser { get; set; }
        internal static string CurrentTableType { get; set; }
        internal static int NumOrder { get; set; }
        internal static Order CurrentOrder { get; set; }
        internal static Customer CurrentCustomer { get; set; }
        internal static Contract CurrentContract { get; set; }
        internal static Contract_Goods CurrentContractGoods { get; set; }
        internal static Contractor CurrentContractor { get; set; }
        internal static Contractor_Goods CurrentContractorGoods { get; set; }
        internal static Contractor_Tel CurrentContractorTel { get; set; }
        internal static Cornices CurrentCornices { get; set; }
        internal static Cust_Tel CurrentCustTel { get; set; }
        internal static Goods CurrentGoods { get; set; }
        internal static Order_Goods CurrentOrderGoods { get; set; }
        internal static Workshop CurrentWorkshop { get; set; }
        //internal static string SelectedContractor { get; set; }

        internal static void CloseApp()
        {
            Environment.Exit(1);
        }
    }
}
