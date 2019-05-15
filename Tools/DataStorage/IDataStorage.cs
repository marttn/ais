using ais.Models;
using System.Collections.Generic;

namespace ais.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddOrder(Order order);
        void RemoveOrder(Order order);
        void UpdateOrder(int index, Order order);

        void AddContract(Contract contract);
        void RemoveContract(Contract contract);
        void UpdateContract(int index, Contract contract);

        void AddContractGoods(Contract_Goods contrgoods);
        void RemoveContractGoods(Contract_Goods contrgoods);
        void UpdateContractGoods(int index, Contract_Goods contrgoods);

        void AddContractor(Contractor contractor);
        void RemoveContractor(Contractor contractor);
        void UpdateContractor(int index, Contractor contractor);

        void AddContractorTel(Contractor_Tel contrtel);
        void RemoveContractorTel(Contractor_Tel contrtel);
        void UpdateContractorTel(int index, Contractor_Tel contrtel);

        void AddContractorGoods(Contractor_Goods contractorgoods);
        void RemoveContractorGoods(Contractor_Goods contractorgoods);
        void UpdateContractorGoods(int index, Contractor_Goods contractorgoods);

        void AddCornices(Cornices cornices);
        void RemoveCornices(Cornices cornices);
        void UpdateCornices(int index, Cornices cornices);

        void AddCustTel(Cust_Tel cust_Tel);
        void RemoveCustTel(Cust_Tel cust_Tel);
        void UpdateCustTel(int index, Cust_Tel cust_Tel);

        void AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        void UpdateCustomer(int index, Customer customer);

        void AddGoods(Goods goods);
        void RemoveGoods(Goods goods);
        void UpdateGoods(int index, Goods goods);

        void AddOrderGoods(Order_Goods order_Goods);
        void RemoveOrderGoods(Order_Goods order_Goods);
        void UpdateOrderGoods(int index, Order_Goods order_Goods);

        void AddWorkshop(Workshop workshop);
        void RemoveWorkshop(Workshop workshop);
        void UpdateWorkshop(int index, Workshop workshop);

        List<Order> OrdersList { get; }
        List<Contract> ContractsList { get; }
        List<Contract_Goods> ContractGoodsList { get; }
        List<Contractor> ContractorsList { get; }
        List<Contractor_Tel> ContractorTelList { get; }
        List<Contractor_Goods> ContractorGoodsList { get; }
        List<Cornices> CornicesList { get; }
        List<Cust_Tel> CustTelsList { get; }
        List<Customer> CustomersList { get; }
        List<Goods> GoodsList { get; }
        List<Order_Goods> OrderGoodsList { get; }
        List<Workshop> WorkshopsList { get; }
    }
}
