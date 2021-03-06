﻿using System;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdCustTelVM
    {
        private RelayCommand<Window> _updTel;

        public UpdCustTelVM()
        {
            try
            {
                if (_conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                _conn.Open();

                SqlCommand query = new SqlCommand("SELECT last_name, name_cust FROM Customer WHERE ID like '" + CurrentCustTel.ID + "%'", _conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    Name = select["last_name"].ToString().Trim(' ') + " " + select["name_cust"].ToString().Trim(' ');
                }
                select.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                _conn?.Close();
            }
        }

        readonly SqlConnection _conn = new SqlConnection(Properties.Settings.Default.ais);

        public Cust_Tel CurrentCustTel { get; } = StationManager.CurrentCustTel;
        public string Name { get; set; }

        public RelayCommand<Window> UpdTel => _updTel ?? (_updTel = new RelayCommand<Window>(UpdImpl, CanUpd));

        private bool CanUpd(Window obj)
        {
            return new Regex("^\\d{10}").IsMatch(CurrentCustTel.TelNum);
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateCustTel(StationManager.CurrentCustTel, CurrentCustTel);
            StationManager.CurrentCustTel = CurrentCustTel;
            obj.Close();
        }
    }
}
