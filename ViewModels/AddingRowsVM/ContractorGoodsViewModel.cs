using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class ContractorGoodsViewModel
    {
        private string nameGoods;
        private string nameContractor;
        private double priceOneProduct;

        private RelayCommand<object> addContractorGoods;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public ContractorGoodsViewModel()
        {
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT Name_contr FROM Contractor", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    ListContractors.Add(select["Name_contr"].ToString().Trim(' '));
                }
                select.Close();
                query = new SqlCommand("SELECT name_g FROM Goods", conn);
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    ListGoods.Add(reader["name_g"].ToString().Trim(' '));
                }
                reader.Close();
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

        public ObservableCollection<string> ListContractors { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListGoods { get; } = new ObservableCollection<string>();

        public string NameGoods
        {
            get => nameGoods;
            set
            {
                nameGoods = value;
                OnPropertyChanged();
            }
        }
        public string NameContractor
        {
            get => nameContractor;
            set
            {
                nameContractor = value;
                OnPropertyChanged();
            }
        }
        public double PriceOneProduct
        {
            get => priceOneProduct;
            set
            {
                priceOneProduct = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand<object> AddContractorGoods
        {
            get => addContractorGoods ?? (addContractorGoods = new RelayCommand<object>(AddImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(NameGoods) &&
                   !string.IsNullOrWhiteSpace(NameContractor) &&
                   !string.IsNullOrWhiteSpace(PriceOneProduct.ToString());
        }

        private void AddImpl(object obj)
        {
            try
            {
                string articul = null, code = null;
                SqlDataReader reader, reader1;
                SqlCommand query;
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                query = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameGoods + "'", conn);
                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    articul = reader["Articul"].ToString();
                }
                reader.Close();
                query = new SqlCommand("SELECT Code_contractor FROM Contractor WHERE Name_contr = '" + NameContractor+ "'", conn);
                reader1 = query.ExecuteReader();
                while(reader1.Read())
                {
                    code = reader1["Code_contractor"].ToString();
                }
                StationManager.CurrentContractorGoods = new Contractor_Goods(articul, code, PriceOneProduct);
                StationManager.DataStorage.AddContractorGoods(StationManager.CurrentContractorGoods);
                MessageBox.Show("row added");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            NavigationManager.Instance.Navigate(ViewType.Admin);
        }



        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
