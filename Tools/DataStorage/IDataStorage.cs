using System;
using ais.Models;
using System.Collections.Generic;

namespace ais.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddOrder(Order order);
        void RemoveOrder(Order order);
        void UpdateOrder(Order order, Order newOrder);

        void AddContract(Contract contract);
        void RemoveContract(Contract contract);
        void UpdateContract(Contract contract, Contract newContract);

        void AddContractGoods(Contract_Goods contrgoods);
        void RemoveContractGoods(Contract_Goods contrgoods);
        void UpdateContractGoods(Contract_Goods contrgoods, Contract_Goods newContract_Goods);

        void AddContractor(Contractor contractor);
        void RemoveContractor(Contractor contractor);
        void UpdateContractor(Contractor contractor, Contractor newContractor);

        void AddContractorTel(Contractor_Tel contrtel);
        void RemoveContractorTel(Contractor_Tel contrtel);
        void UpdateContractorTel(Contractor_Tel contrtel, Contractor_Tel newContractor_Tel);

        void AddContractorGoods(Contractor_Goods contractorgoods);
        void RemoveContractorGoods(Contractor_Goods contractorgoods);
        void UpdateContractorGoods(Contractor_Goods contractorgoods, Contractor_Goods newContractor_Goods);

        void AddCornices(Cornices cornices);
        void RemoveCornices(Cornices cornices);
        void UpdateCornices(Cornices cornices, Cornices newCornices);

        void AddCustTel(Cust_Tel cust_Tel);
        void RemoveCustTel(Cust_Tel cust_Tel);
        void UpdateCustTel(Cust_Tel cust_Tel, Cust_Tel newCust_Tel);

        void AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        void UpdateCustomer(Customer customer, Customer newCustomer);

        void AddGoods(Goods goods);
        void RemoveGoods(Goods goods);
        void UpdateGoods(Goods goods, Goods newGoods);

        void AddOrderGoods(Order_Goods order_Goods);
        void RemoveOrderGoods(Order_Goods order_Goods);
        void UpdateOrderGoods(Order_Goods order_Goods, Order_Goods newOrder_Goods);

        void AddWorkshop(Workshop workshop);
        void RemoveWorkshop(Workshop workshop);
        void UpdateWorkshop(Workshop workshop, Workshop newWorkshop);

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
        
        List<string> NameContractors();
        
        List<Users> UsersList { get; }

        List<string> ListCurtains();
        List<string> ListCornices();
        List<string> ListAccs();
        List<string> ListContracts();
        List<string> ListCustomers();
        List<string> ListOrderNums();
        List<string> ListCorniceInstallers();
        List<string> ListNameWorkshops();


        List<Order> OrderSelPeriod(DateTime s, DateTime e);
        List<Contract> ContractSelPeriod(DateTime s, DateTime e);
        string Income(DateTime s, DateTime e);
        string Profit(DateTime s, DateTime e);

        string Expenses(DateTime s, DateTime e);
        string RevenueAdmin(DateTime s, DateTime e);

        List<Customer> MostProfitableCustomers(bool asc);
        List<Order> CustomersOrdersList(string Id);

        void DeleteUser(Users user);

        List<ContractorsPrices> CurrentContractorsPrices(string name);

    }
}
