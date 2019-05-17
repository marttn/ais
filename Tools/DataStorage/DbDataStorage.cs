using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ais.Models;
using ais.Tools.Managers;

namespace ais.Tools.DataStorage
{
    class DbDataStorage : IDataStorage
    {
        public List<Workshop> workshopsList;
        public List<Order> ordersList;
        public List<Contract> contractsList;
        public List<Contract_Goods> contractGoodsList;
        public List<Contractor> contractorsList;
        public List<Contractor_Goods> contractorGoodsList;
        public List<Contractor_Tel> contractorTelList;
        public List<Cornices> cornicesList;
        public List<Cust_Tel> custTelsList;
        public List<Customer> customersList;
        public List<Goods> goodsList;
        public List<Order_Goods> orderGoodsList;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public List<Order> OrdersList { get => ordersList; }
        public List<Contract> ContractsList { get => contractsList; }
        public List<Contract_Goods> ContractGoodsList { get => contractGoodsList; }
        public List<Contractor> ContractorsList { get => contractorsList; }
        public List<Contractor_Tel> ContractorTelList { get => contractorTelList; }
        public List<Contractor_Goods> ContractorGoodsList { get => contractorGoodsList; }
        public List<Cornices> CornicesList { get => cornicesList; }
        public List<Cust_Tel> CustTelsList { get => custTelsList; }
        public List<Customer> CustomersList { get => customersList; }
        public List<Goods> GoodsList { get => goodsList; }
        public List<Order_Goods> OrderGoodsList { get => orderGoodsList; }
        public List<Workshop> WorkshopsList { get => workshopsList; }

        public DbDataStorage()
        {
            // SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);
            workshopsList = new List<Workshop>();
            ordersList = new List<Order>();
            contractsList = new List<Contract>();
            contractGoodsList = new List<Contract_Goods>();
            contractorsList = new List<Contractor>();
            contractorGoodsList = new List<Contractor_Goods>();
            contractorTelList = new List<Contractor_Tel>();
            cornicesList = new List<Cornices>();
            custTelsList = new List<Cust_Tel>();
            customersList = new List<Customer>();
            goodsList = new List<Goods>();
            orderGoodsList = new List<Order_Goods>();
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand cmd1 = new SqlCommand($"select * from Customer", conn);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dataTable1 = new DataTable();
                da1.Fill(dataTable1);
                
                    for (int i = 0; i < dataTable1.Rows.Count; ++i)
                    {
                        customersList.Add(new Customer(
                            dataTable1.Rows[i][0].ToString() ?? "",
                            dataTable1.Rows[i][1].ToString() ?? "",
                            dataTable1.Rows[i][2].ToString() ?? "",
                            dataTable1.Rows[i][3].ToString() ?? "",
                            dataTable1.Rows[i][4].ToString() ?? "",
                            dataTable1.Rows[i][5].ToString() ?? "",
                            dataTable1.Rows[i][6].ToString() ?? "",
                            Convert.ToInt32(dataTable1.Rows[i][7]),
                            Convert.ToInt32(dataTable1.Rows[i][8]),
                            dataTable1.Rows[i][9].ToString() ?? ""));
                    }
                //MessageBox.Show(customersList[2].ID);

                SqlCommand cmd2 = new SqlCommand($"select * from Cust_Tel", conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dataTable2 = new DataTable();
                da2.Fill(dataTable2);

                for (int i = 0; i < dataTable2.Rows.Count; ++i)
                    {
                        custTelsList.Add(new Cust_Tel
                            (dataTable2.Rows[i][0].ToString() ?? "",
                             dataTable2.Rows[i][1].ToString() ?? ""));
                    }

                SqlCommand cmd3 = new SqlCommand($"select * from Cornices", conn);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataTable dataTable3 = new DataTable();
                da3.Fill(dataTable3);
                    for (int i = 0; i < dataTable3.Rows.Count; ++i)
                    {
                        cornicesList.Add(new Cornices(
                             dataTable3.Rows[i][0].ToString() ?? "",
                             dataTable3.Rows[i][1].ToString() ?? "",
                             dataTable3.Rows[i][2].ToString() ?? "",
                             dataTable3.Rows[i][3].ToString() ?? "",
                             dataTable3.Rows[i][4].ToString() ?? "",
                             dataTable3.Rows[i][5].ToString() ?? "",
                             dataTable3.Rows[i][6].ToString() ?? "",
                             dataTable3.Rows[i][7] == DBNull.Value ? 0 : Convert.ToInt32(dataTable3.Rows[i][7]),
                             dataTable3.Rows[i][8] == DBNull.Value ? 0 : Convert.ToInt32(dataTable3.Rows[i][8]),
                             dataTable3.Rows[i][9].ToString() ?? "",
                             dataTable3.Rows[i][10].ToString() ?? "",
                             dataTable3.Rows[i][11] == DBNull.Value ? 0 : Convert.ToDouble(dataTable3.Rows[i][11])));
                    }

                SqlCommand cmd4 = new SqlCommand($"select * from Workshop", conn);
                SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                DataTable dataTable4 = new DataTable();
                da4.Fill(dataTable4);
                for (int i = 0; i < dataTable4.Rows.Count; ++i)
                    {
                        workshopsList.Add(new Workshop(
                            dataTable4.Rows[i][0].ToString() ?? "",
                            dataTable4.Rows[i][1].ToString() ?? "",
                            dataTable4.Rows[i][2].ToString() ?? "",
                            dataTable4.Rows[i][3].ToString() ?? "",
                            dataTable4.Rows[i][4].ToString() ?? "",
                            dataTable4.Rows[i][5].ToString() ?? "",
                            dataTable4.Rows[i][6] == DBNull.Value ? 0 : Convert.ToInt32(dataTable4.Rows[i][6]),
                            dataTable4.Rows[i][7] == DBNull.Value ? 0 : Convert.ToInt32(dataTable4.Rows[i][7]),
                            dataTable4.Rows[i][8].ToString() ?? "",
                            dataTable4.Rows[i][9] == DBNull.Value ? 0 : Convert.ToDouble(dataTable4.Rows[i][9])));
                    }


                SqlCommand cmd5 = new SqlCommand($"select * from [Order]", conn);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
                DataTable dataTable5 = new DataTable();
                da5.Fill(dataTable5);
                for (int i = 0; i < dataTable5.Rows.Count; ++i)
                {
                        ordersList.Add(new Order(
                            dataTable5.Rows[i][0].ToString() ?? "",
                            (DateTime)dataTable5.Rows[i][1],
                            dataTable5.Rows[i][2].ToString() ?? "",
                            dataTable5.Rows[i][3].ToString() ?? "",
                            dataTable5.Rows[i][4].ToString() ?? ""));
                }
                StationManager.NumOrder = int.Parse(dataTable5.Rows[dataTable5.Rows.Count - 1][0].ToString());
                StationManager.CurrentOrder = ordersList[dataTable5.Rows.Count - 1];


                SqlCommand cmd6 = new SqlCommand($"select * from Contractor", conn);
                SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
                DataTable dataTable6 = new DataTable();
                da6.Fill(dataTable6);
                for (int i = 0; i < dataTable6.Rows.Count; ++i)
                {
                        contractorsList.Add(new Contractor(
                            dataTable6.Rows[i][0].ToString() ?? "",
                            dataTable6.Rows[i][1].ToString() ?? "",
                            dataTable6.Rows[i][2].ToString() ?? "",
                            dataTable6.Rows[i][3].ToString() ?? "",
                            dataTable6.Rows[i][4].ToString() ?? "",
                            Convert.ToInt32(dataTable6.Rows[i][5]),
                            Convert.ToInt32(dataTable6.Rows[i][6]),
                            dataTable6.Rows[i][7].ToString() ?? "",
                            dataTable6.Rows[i][8].ToString() ?? ""));
                }


                SqlCommand cmd7 = new SqlCommand($"select * from Contractor_Tel", conn);
                SqlDataAdapter da7 = new SqlDataAdapter(cmd7);
                DataTable dataTable7 = new DataTable();
                da7.Fill(dataTable7);
                for (int i = 0; i < dataTable7.Rows.Count; ++i)
                {
                        contractorTelList.Add(new Contractor_Tel(
                            dataTable7.Rows[i][0].ToString() ?? "",
                            dataTable7.Rows[i][1].ToString() ?? ""));
                }


                SqlCommand cmd8 = new SqlCommand($"select * from Goods", conn);
                SqlDataAdapter da8 = new SqlDataAdapter(cmd8);
                DataTable dataTable8 = new DataTable();
                da8.Fill(dataTable8);
                for (int i = 0; i < dataTable8.Rows.Count; ++i)
                {
                        goodsList.Add(new Goods(
                            dataTable8.Rows[i][0].ToString() ?? "",
                            dataTable8.Rows[i][1].ToString() ?? "",
                            dataTable8.Rows[i][2].ToString() ?? "",
                            dataTable8.Rows[i][3].ToString() ?? "",
                            dataTable8.Rows[i][4].ToString() ?? ""));
                }
                SqlCommand cmd9 = new SqlCommand($"select * from Contractor_Goods", conn);
                SqlDataAdapter da9 = new SqlDataAdapter(cmd9);
                DataTable dataTable9 = new DataTable();
                da9.Fill(dataTable9);
                for (int i = 0; i < dataTable9.Rows.Count; ++i)
                {
                        contractorGoodsList.Add(new Contractor_Goods(
                            dataTable9.Rows[i][0].ToString() ?? "",
                            dataTable9.Rows[i][1].ToString() ?? "",
                            Convert.ToDouble(dataTable9.Rows[i][2])));
                }


                SqlCommand cmd10 = new SqlCommand($"select * from Order_Goods", conn);
                SqlDataAdapter da10 = new SqlDataAdapter(cmd10);
                DataTable dataTable10 = new DataTable();
                da10.Fill(dataTable10);
                for (int i = 0; i < dataTable10.Rows.Count; ++i)
                {
                        orderGoodsList.Add(new Order_Goods(
                            dataTable10.Rows[i][0].ToString() ?? "",
                            dataTable10.Rows[i][1].ToString() ?? "",
                            Convert.ToInt32(dataTable10.Rows[i][2])));
                }


                SqlCommand cmd11 = new SqlCommand($"select * from Contract", conn);
                SqlDataAdapter da11 = new SqlDataAdapter(cmd11);
                DataTable dataTable11 = new DataTable();
                da11.Fill(dataTable11);
                for (int i = 0; i < dataTable11.Rows.Count; ++i)
                {
                        contractsList.Add(new Contract(
                            dataTable11.Rows[i][0].ToString() ?? "",
                            (DateTime)dataTable11.Rows[i][1],
                            dataTable11.Rows[i][2].ToString() ?? ""));
                }


                SqlCommand cmd12 = new SqlCommand($"select * from Contract_Goods", conn);
                SqlDataAdapter da12 = new SqlDataAdapter(cmd12);
                DataTable dataTable12 = new DataTable();
                da12.Fill(dataTable12);
                for (int i = 0; i < dataTable12.Rows.Count; ++i)
                {
                        contractGoodsList.Add(new Contract_Goods(
                            dataTable12.Rows[i][0].ToString() ?? "",
                            dataTable12.Rows[i][1].ToString() ?? "",
                            Convert.ToInt32(dataTable12.Rows[i][2])));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    



        public void AddContract(Contract contract)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("INSERT INTO Contract VALUES (@Num_contract, @date_contract, @Code_contractor)", conn);
                query.Parameters.AddWithValue("@Num_contract", contract.NumContract);
                query.Parameters.AddWithValue("@date_contract", contract.DateContract);
                query.Parameters.AddWithValue("@Code_contractor", contract.CodeContractor);
                query.ExecuteNonQuery();
                ContractsList.Add(contract);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddContractGoods(Contract_Goods contrgoods)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("INSERT INTO Contract VALUES (@Num_contract, @Articul, @quantity_contract)", conn);
                query.Parameters.AddWithValue("@Num_contract", contrgoods.NumContract);
                query.Parameters.AddWithValue("@Articul", contrgoods.Articul);
                query.Parameters.AddWithValue("@quantity_contract", contrgoods.Quantity);
                query.ExecuteNonQuery();
                ContractGoodsList.Add(contrgoods);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddContractor(Contractor contractor)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Contractor VALUES (@Code_contractor,  @name_contr, @city, @street, @building, @porch, @office, @account_contr, @email)", conn);
                query.Parameters.AddWithValue("@Code_contractor", contractor.CodeContractor);
                query.Parameters.AddWithValue("@Name_contr", contractor.NameContractor);
                query.Parameters.AddWithValue("@city", contractor.City);
                query.Parameters.AddWithValue("@street", contractor.Street);
                query.Parameters.AddWithValue("@building", contractor.Building);
                query.Parameters.AddWithValue("@porch", contractor.Porch);
                query.Parameters.AddWithValue("@office", contractor.Office);
                query.Parameters.AddWithValue("@account_contr", contractor.Account);
                query.Parameters.AddWithValue("@email", contractor.Email);
                query.ExecuteNonQuery();
                ContractorsList.Add(contractor);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddContractorTel(Contractor_Tel contrtel)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Contractor VALUES (@Tel_num, @Code_contractor)", conn);
                query.Parameters.AddWithValue("@Tel_num", contrtel.TelNum);
                query.Parameters.AddWithValue("@Code_contractor", contrtel.CodeContractor);         
                query.ExecuteNonQuery();
                ContractorTelList.Add(contrtel);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void AddOrder(Order order)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("INSERT INTO [Order] VALUES (@Num_ord, @date_ord, @ID, @Code_workshop, @Ipn)", conn);
                query.Parameters.AddWithValue("@Num_ord", order.NumOrd);
                query.Parameters.AddWithValue("@date_ord", order.DateOrd);
                query.Parameters.AddWithValue("@ID", order.ID);
                query.Parameters.AddWithValue("@Code_workshop", (object)order.CodeWorkshop ?? DBNull.Value);
                query.Parameters.AddWithValue("@Ipn", (object)order.Ipn ?? DBNull.Value);
                query.ExecuteNonQuery();
                ordersList.Add(order);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveContract(Contract contract)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Contract WHERE Num_contract = '" + contract.NumContract + "'", conn);
                query.ExecuteNonQuery();
                ContractsList.Remove(contract);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveContractGoods(Contract_Goods contrgoods)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Contract_Goods WHERE Num_contract = '" + contrgoods.NumContract + "' AND Articul = '" + contrgoods.Articul + "'", conn);
                query.ExecuteNonQuery();
                ContractGoodsList.Remove(contrgoods);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveContractor(Contractor contractor)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Contractor WHERE Code_contractor = '" + contractor.CodeContractor + "'", conn);
                query.ExecuteNonQuery();
                ContractorsList.Remove(contractor);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveContractorTel(Contractor_Tel contrtel)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Contractor_Tel WHERE Code_contractor = '" + contrtel.TelNum + "'", conn);
                query.ExecuteNonQuery();
                ContractorTelList.Remove(contrtel);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveOrder(Order order)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM [Order] WHERE Num_ord = '" + order.NumOrd +  "'", conn);
                query.ExecuteNonQuery();
                ordersList.Remove(order);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateContract(int index, Contract contract)
        {
            throw new NotImplementedException();
        }

        public void UpdateContractGoods(int index, Contract_Goods contrgoods)
        {
            throw new NotImplementedException();
        }

        public void UpdateContractor(int index, Contractor contractor)
        {
            throw new NotImplementedException();
        }

        public void UpdateContractorTel(int index, Contractor_Tel contrtel)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(int index, Order order)
        {
            throw new NotImplementedException();
        }

        public void AddContractorGoods(Contractor_Goods contractorgoods)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Contractor_Goods VALUES (@Articul, @Code_contractor, @price_1_product)", conn);
                query.Parameters.AddWithValue("@Articul", contractorgoods.Articul);
                query.Parameters.AddWithValue("@Code_contractor", contractorgoods.CodeContractor);
                query.Parameters.AddWithValue("@price_1_product", contractorgoods.PriceOneProduct);
                query.ExecuteNonQuery();
                ContractorGoodsList.Add(contractorgoods);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveContractorGoods(Contractor_Goods contractorgoods)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Contractor_Goods WHERE Articul = '" + contractorgoods.Articul + "' AND Code_contractor = '"+ contractorgoods.CodeContractor + "'", conn);
                query.ExecuteNonQuery();
                ContractorGoodsList.Remove(contractorgoods);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateContractorGoods(int index, Contractor_Goods contractorgoods)
        {
            throw new NotImplementedException();
        }

        public void AddCornices(Cornices cornices)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Cornices VALUES (@Ipn, @last_name, @name_c, @middle_name, @city, @street, @building, @porch, @appartment, @account_cornice, @tel_num, price_1_cornice)", conn);
                query.Parameters.AddWithValue("@Ipn", cornices.Ipn);
                query.Parameters.AddWithValue("@last_name", cornices.LastName);
                query.Parameters.AddWithValue("@name_c", cornices.Name);
                query.Parameters.AddWithValue("@middle_name", (object)cornices.MiddleName ?? DBNull.Value);
                query.Parameters.AddWithValue("@city", (object)cornices.City ?? DBNull.Value);
                query.Parameters.AddWithValue("@street", (object)cornices.Street ?? DBNull.Value);
                query.Parameters.AddWithValue("@building", (object)cornices.Building ?? DBNull.Value);
                query.Parameters.AddWithValue("@porch", (object)cornices.Porch ?? DBNull.Value);
                query.Parameters.AddWithValue("@appartment", (object)cornices.Appartment ?? DBNull.Value);
                query.Parameters.AddWithValue("@account_cornice", cornices.AccountCornice);
                query.Parameters.AddWithValue("@tel_num", cornices.TelNum);
                query.Parameters.AddWithValue("@price_1_cornice", cornices.PriceOneCornice);
                query.ExecuteNonQuery();
                CornicesList.Add(cornices);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveCornices(Cornices cornices)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Cornices WHERE Ipn = '" + cornices.Ipn + "'", conn);
                query.ExecuteNonQuery();
                CornicesList.Remove(cornices);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateCornices(int index, Cornices cornices)
        {
            throw new NotImplementedException();
        }

        public void AddCustTel(Cust_Tel cust_Tel)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Cust_Tel VALUES (@Tel_num, @ID)", conn);
                query.Parameters.AddWithValue("@Tel_num", cust_Tel.TelNum);
                query.Parameters.AddWithValue("@ID", cust_Tel.ID);
                query.ExecuteNonQuery();
                CustTelsList.Add(cust_Tel);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveCustTel(Cust_Tel cust_Tel)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Cust_Tel WHERE Tel_num = '" + cust_Tel.TelNum + "'", conn);
                query.ExecuteNonQuery();
                CustTelsList.Remove(cust_Tel);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateCustTel(int index, Cust_Tel cust_Tel)
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                string id;
                do
                {
                    id = RandomString(10);
                }
                while (CustomersList.Any(u => u.ID.Equals(id)));
                customer.ID = id;
                SqlCommand query = new SqlCommand("INSERT INTO Customer VALUES (@ID, @last_name, @name_cust, @middle_name, @city, @street, @building, @porch, @appartment, @email)", conn);
                query.Parameters.AddWithValue("@ID", customer.ID);
                query.Parameters.AddWithValue("@last_name", customer.LastName);
                query.Parameters.AddWithValue("@name_cust", customer.Name);
                query.Parameters.AddWithValue("@middle_name", (object)customer.MiddleName?? DBNull.Value);
                query.Parameters.AddWithValue("@city", customer.City);
                query.Parameters.AddWithValue("@street", customer.Street);
                query.Parameters.AddWithValue("@building", customer.Building);
                query.Parameters.AddWithValue("@porch", customer.Porch);
                query.Parameters.AddWithValue("@appartment", customer.Appartment);
                query.Parameters.AddWithValue("@email", customer.Email);
                query.ExecuteNonQuery();
                CustomersList.Add(customer);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Customer WHERE ID = '" + customer.ID + "'", conn);
                query.ExecuteNonQuery();
                CustomersList.Remove(customer);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateCustomer(int index, Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddGoods(Goods goods)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                string art;
                do
                {
                    art = RandomString(10);
                }
                while (GoodsList.Any(u => u.Articul.Equals(art)));
                goods.Articul = art;
                SqlCommand query = new SqlCommand("INSERT INTO Goods VALUES (@Articul, @name_g, @type, @material, @characteristics)", conn);
                query.Parameters.AddWithValue("@Articul", goods.Articul);
                query.Parameters.AddWithValue("@name_g", goods.Name);
                query.Parameters.AddWithValue("@type", goods.Type);
                query.Parameters.AddWithValue("@material", goods.Material);
                query.Parameters.AddWithValue("@characteristics", goods.Characteristics);
                query.ExecuteNonQuery();
                GoodsList.Add(goods);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveGoods(Goods goods)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Goods WHERE Articul = '" + goods.Articul + "'", conn);
                query.ExecuteNonQuery();
                GoodsList.Remove(goods);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateGoods(int index, Goods goods)
        {
            throw new NotImplementedException();
        }

        public void AddOrderGoods(Order_Goods order_Goods)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Order_Goods VALUES (@Num_ord, @Articul, @quantity_goods)", conn);
                query.Parameters.AddWithValue("@Num_ord", order_Goods);
                query.Parameters.AddWithValue("@Articul", order_Goods);
                query.Parameters.AddWithValue("@quantity_goods", order_Goods);
                query.ExecuteNonQuery();
                OrderGoodsList.Add(order_Goods);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveOrderGoods(Order_Goods order_Goods)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Order_Goods WHERE Num_ord = '" + order_Goods.NumOrd + "' AND Articul = '" + order_Goods.Articul + "'", conn);
                query.ExecuteNonQuery();
                OrderGoodsList.Remove(order_Goods);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateOrderGoods(int index, Order_Goods order_Goods)
        {
            throw new NotImplementedException();
        }

        public void AddWorkshop(Workshop workshop)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("INSERT INTO Cornices VALUES (@Code_workshop, @name_shop, @tel_num, @city, @street, @building, @porch, @office, @account_shop, @price_1_curtain)", conn);
                query.Parameters.AddWithValue("@Code_workshop", workshop.CodeWorkshop);
                query.Parameters.AddWithValue("@name_shop", workshop.Name);
                query.Parameters.AddWithValue("@tel_num", workshop.TelNum);
                query.Parameters.AddWithValue("@city", workshop.City);
                query.Parameters.AddWithValue("@street", workshop.Street);
                query.Parameters.AddWithValue("@building", workshop.Building);
                query.Parameters.AddWithValue("@porch", workshop.Porch);
                query.Parameters.AddWithValue("@office", workshop.Office);
                query.Parameters.AddWithValue("@account_shop", workshop.AccountShop);
                query.Parameters.AddWithValue("@price_1_curtain", workshop.PriceOneCurtain);
                query.ExecuteNonQuery();
                WorkshopsList.Add(workshop);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveWorkshop(Workshop workshop)
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Workshop WHERE Code_workshop = '" + workshop.CodeWorkshop+ "'", conn);
                query.ExecuteNonQuery();
                WorkshopsList.Remove(workshop);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateWorkshop(int index, Workshop workshop)
        {
            throw new NotImplementedException();
        }

        
        public static string RandomString(int length)
        {
            var chars = "0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
