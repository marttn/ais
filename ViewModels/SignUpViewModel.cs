using ais.Tools;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows;
using System.Security.Cryptography;
using ais.Models;
using ais.Tools.Managers;

namespace ais.ViewModels
{
    class SignUpViewModel
    {
        private string _name;
        private string _lastName;
        private string _login;
        private string _password;
        private string _selectedType;
        private RelayCommand<object> _signUp;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand<object> SignUpCommand
        {
            get
            {
                return _signUp ?? (_signUp = new RelayCommand<object>(
                           SignUpImplementation, o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) 
                && !string.IsNullOrWhiteSpace(_lastName) 
                && !string.IsNullOrWhiteSpace(_login)
                && !string.IsNullOrWhiteSpace(_password);
        }

        private void SignUpImplementation(object obj)
        {

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                //hashing
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string savedPasswordHash = Convert.ToBase64String(hashBytes);
                //end of hashing
                SqlCommand query = new SqlCommand("INSERT INTO Users (login, password, name, lastname, usertype) VALUES('" + Login + "', '" + savedPasswordHash + "', '" + Name + "', '" + LastName + "', '" + SelectedType.Replace("System.Windows.Controls.ComboBoxItem: ", "") + "')", conn);
                //MessageBox.Show(savedPasswordHash+"\n"+Login + "\n" +Name + "\n" +LastName + "\n" + SelectedType.Replace("System.Windows.Controls.ComboBoxItem: ", ""));
                query.ExecuteNonQuery();
                MessageBox.Show("Success");
                StationManager.DataStorage.UsersList.Add(new Users(Name, LastName, Login, SelectedType.Replace("System.Windows.Controls.ComboBoxItem: ", "")));
                conn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message  + "\n" + exc.Source + "\n"+ exc.StackTrace);
            }
               
            
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
