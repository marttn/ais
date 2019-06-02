using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows;

namespace ais.ViewModels
{
    class SignInViewModel
    {
        private string _login;
        private string _password;
        private RelayCommand<object> _signIn;
        private RelayCommand<object> _signUp;

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

        public RelayCommand<object> SignIn
        {
            get
            {
                return _signIn ?? (_signIn = new RelayCommand<object>(
                           SignInImplementation, o => CanExecuteCommand()));
            }
        }
        public RelayCommand<object> SignUp
        {
            get
            {
                return _signUp ?? (_signUp = new RelayCommand<object>(
                           SignUpImplementation));
            }
        }

        private void SignUpImplementation(object obj)
        {
            Thread.Sleep(150);
            NavigationManager.Instance.Navigate(ViewType.SignUp);
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_login) && !string.IsNullOrWhiteSpace(_password);
        }

        private void SignInImplementation(object obj)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                
                SqlCommand query = new SqlCommand("SELECT * FROM Users WHERE login = '" + Login +"'", conn);
                SqlDataReader select = query.ExecuteReader();
                string result = "", name = "", lastname = "", login = "", type = "";
                while (select.Read())
                {
                    result = select["password"].ToString();
                    name = select["name"].ToString();
                    lastname = select["lastname"].ToString();
                    login = select["login"].ToString();
                    type = select["usertype"].ToString();
                }
                //MessageBox.Show(result);
                byte[] hashBytes = Convert.FromBase64String(result);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                int ok = 1;
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        ok = 0;
                if (ok==1)
                {
                    MessageBox.Show("Success");
                   // MessageBox.Show(name+" "+ type);
                    StationManager.CurrentUser = new Users(name, lastname, login, type);
                    NavigationManager.Instance.Navigate(type.Equals("Admin") ? ViewType.Admin : ViewType.Designer);
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
                
                conn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
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
